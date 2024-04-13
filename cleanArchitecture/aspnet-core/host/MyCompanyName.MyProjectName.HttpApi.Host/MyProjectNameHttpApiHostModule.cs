using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;
using Microsoft.OpenApi.Models;
using MyCompanyName.MyProjectName.Core;
using MyCompanyName.MyProjectName.HttpApi;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Json;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.Swashbuckle;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.VirtualFileSystem;

namespace MyCompanyName.MyProjectName;

[DependsOn(
    typeof(MyProjectNameInfrastructureModule),
    typeof(MyProjectNameHttpApiModule),
    
    typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
    typeof(AbpAutofacModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpTenantManagementEntityFrameworkCoreModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpSwashbuckleModule),
    typeof(AbpAutofacModule)
    )]
public class MyProjectNameHttpApiHostModule : AbpModule
{
    private const bool MultiTenancyConstsIsEnabled = false;

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        // SqlServer
        Configure<AbpDbContextOptions>(options =>
        {
            options.UseSqlServer();
        });

        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = MultiTenancyConstsIsEnabled;
        });
        
        // 日志
        Configure<AbpAuditingOptions>(options =>
        {
            options.ApplicationName = MyCompanyNameMyProjectNameCoreOptions.ModuleName;
            options.IsEnabledForGetRequests = false;
        });
        
        // 时间格式 
        Configure<AbpJsonOptions>(options =>
        {
            options.OutputDateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        });

        if (hostingEnvironment.IsDevelopment())
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.ReplaceEmbeddedByPhysical<MyProjectNameCoreModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}MyCompanyName.MyProjectName.Core", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<MyProjectNameInfrastructureModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}MyCompanyName.MyProjectName.Infrastructure", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<MyProjectNameHttpApiModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}MyCompanyName.MyProjectName.HttpApi", Path.DirectorySeparatorChar)));
            });
        }

        context.Services.AddAbpSwaggerGenWithOAuth(
            configuration["AuthServer:Authority"]!,
            new Dictionary<string, string>
            {
                { MyCompanyNameMyProjectNameCoreOptions.ModuleName,  MyCompanyNameMyProjectNameCoreOptions.ModuleName + " API"}
            },
            options =>
            {
                
                options.SwaggerDoc(MyCompanyNameMyProjectNameCoreOptions.ModuleName, new OpenApiInfo {Title = MyCompanyNameMyProjectNameCoreOptions.ModuleName + " API", Version = "v1"});
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
                
                var directoryInfo = new DirectoryInfo(AppContext.BaseDirectory);
                var fileInfos = directoryInfo.GetFileSystemInfos()
                    .Where(a => a.Extension == ".xml")
                    .Where(a => a.Name.EndsWith("MyProjectName.Core.xml") || a.Name.EndsWith("HttpApi.xml"));
        
                foreach (var info in fileInfos)
                {
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, info.Name);
                    options.IncludeXmlComments(xmlPath,true);
                }
            });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
            options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
            options.Languages.Add(new LanguageInfo("en", "en", "English"));
        });

        context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = configuration["AuthServer:Authority"];
                options.RequireHttpsMetadata = configuration.GetValue<bool>("AuthServer:RequireHttpsMetadata");
                options.Audience = MyCompanyNameMyProjectNameCoreOptions.ModuleName;
            });

        Configure<AbpDistributedCacheOptions>(options =>
        {
            options.KeyPrefix = MyCompanyNameMyProjectNameCoreOptions.ModuleName + ":";
        });

        var dataProtectionBuilder = context.Services.AddDataProtection().SetApplicationName(MyCompanyNameMyProjectNameCoreOptions.ModuleName);
        if (!hostingEnvironment.IsDevelopment())
        {
            var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]!);
            dataProtectionBuilder.PersistKeysToStackExchangeRedis(redis, MyCompanyNameMyProjectNameCoreOptions.ModuleName + "-Protection-Keys");
        }

        context.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins(
                        configuration["App:CorsOrigins"]?
                            .Split(",", StringSplitOptions.RemoveEmptyEntries)
                            .Select(o => o.RemovePostFix("/"))
                            .ToArray() ?? Array.Empty<string>()
                    )
                    .WithAbpExposedHeaders()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();
        if (MultiTenancyConstsIsEnabled)
        {
            app.UseMultiTenancy();
        }
        app.UseAbpRequestLocalization();
        app.UseAuthorization();
        app.UseSwagger();
        app.UseAbpSwaggerUI(options =>
        {
            options.SwaggerEndpoint($"/swagger/{MyCompanyNameMyProjectNameCoreOptions.ModuleName}/swagger.json", MyCompanyNameMyProjectNameCoreOptions.ModuleName +" API");

            var configuration = context.GetConfiguration();
            options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
            options.OAuthScopes(MyCompanyNameMyProjectNameCoreOptions.ModuleName);
        });
        
        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();
    }
}

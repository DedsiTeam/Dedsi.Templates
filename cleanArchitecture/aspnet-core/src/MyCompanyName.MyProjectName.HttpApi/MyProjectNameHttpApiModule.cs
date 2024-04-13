using Microsoft.Extensions.DependencyInjection;
using MyCompanyName.MyProjectName.Core;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace MyCompanyName.MyProjectName.HttpApi;

[DependsOn(
    typeof(MyProjectNameCoreModule),
    typeof(AbpAspNetCoreMvcModule)
)]
public class MyProjectNameHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(MyProjectNameHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {

    }
}
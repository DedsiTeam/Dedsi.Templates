using Microsoft.Extensions.DependencyInjection;
using MyCompanyName.MyProjectName.AspNetCore;
using Volo.Abp.Modularity;

namespace MyCompanyName.MyProjectName;

[DependsOn(
    typeof(MyProjectNameDomainModule),
    typeof(MyProjectNameAspNetCoreModule)
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
using Microsoft.Extensions.DependencyInjection;
using MyCompanyName.MyProjectName.Core;
using MyCompanyName.MyProjectName.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace MyCompanyName.MyProjectName;

[DependsOn(
    typeof(MyProjectNameCoreModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class MyProjectNameInfrastructureModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<MyProjectNameDbContext>(options =>
        {
            options.AddDefaultRepositories(true);
        });
        
    }
}
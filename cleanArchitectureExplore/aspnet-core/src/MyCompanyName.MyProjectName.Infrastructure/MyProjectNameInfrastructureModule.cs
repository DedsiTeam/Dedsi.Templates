using MyCompanyName.MyProjectName.Core;
using Volo.Abp.Modularity;

namespace MyCompanyName.MyProjectName;

[DependsOn(
    typeof(MyProjectNameCoreModule),
    typeof(MyProjectNameSqlSugarModule)
)]
public class MyProjectNameInfrastructureModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        
    }
}
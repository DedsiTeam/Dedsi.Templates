using MyCompanyName.MyProjectName.Extensions;
using Volo.Abp.Modularity;

namespace MyCompanyName.MyProjectName;

[DependsOn(
    typeof(MyProjectNameDomainModule),
    typeof(MyProjectNameSqlSugarModule)
)]
public class MyProjectNameInfrastructureModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.ConfigureSqlSugar("MyProjectNameDB");
    }
}
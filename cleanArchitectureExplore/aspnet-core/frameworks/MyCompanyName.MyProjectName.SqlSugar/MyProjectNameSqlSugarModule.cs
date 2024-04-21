using MyCompanyName.MyProjectName.Core;
using Volo.Abp.Modularity;

namespace MyCompanyName.MyProjectName;

[DependsOn(
    typeof(MyProjectNameCoreModule)
)]
public class MyProjectNameSqlSugarModule : AbpModule
{
    
}
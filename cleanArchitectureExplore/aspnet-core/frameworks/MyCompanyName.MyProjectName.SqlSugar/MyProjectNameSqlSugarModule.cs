using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace MyCompanyName.MyProjectName;

[DependsOn(
    typeof(AbpAspNetCoreMvcModule)
)]
public class MyProjectNameSqlSugarModule : AbpModule
{
    
}
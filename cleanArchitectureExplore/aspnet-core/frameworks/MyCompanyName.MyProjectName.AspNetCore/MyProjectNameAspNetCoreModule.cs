using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace MyCompanyName.MyProjectName.AspNetCore;

[DependsOn(
    typeof(AbpAspNetCoreMvcModule)
)]
public class MyProjectNameAspNetCoreModule : AbpModule
{
    
}
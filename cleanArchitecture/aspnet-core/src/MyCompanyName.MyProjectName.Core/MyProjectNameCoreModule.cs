using Volo.Abp.Application;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace MyCompanyName.MyProjectName.Core;

[DependsOn(
    typeof(AbpDddApplicationModule),
    typeof(AbpDddDomainModule)
)]
public class MyProjectNameCoreModule : AbpModule
{
    
}
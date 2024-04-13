﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace MyCompanyName.MyProjectName;

[DependsOn(
    typeof(MyProjectNameDomainModule),
    typeof(MyProjectNameApplicationContractsModule),
    typeof(AbpDddApplicationModule)
    )]
public class MyProjectNameApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {

    }
}

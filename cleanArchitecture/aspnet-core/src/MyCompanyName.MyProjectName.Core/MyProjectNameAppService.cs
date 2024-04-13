using Volo.Abp.Application.Services;

namespace MyCompanyName.MyProjectName.Core.Applications;

public abstract class MyProjectNameAppService : ApplicationService
{
    protected MyProjectNameAppService()
    {
        ObjectMapperContext = typeof(MyProjectNameCoreModule);
    }
}
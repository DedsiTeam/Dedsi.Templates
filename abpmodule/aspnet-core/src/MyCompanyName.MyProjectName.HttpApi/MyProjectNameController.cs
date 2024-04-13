using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCompanyName.MyProjectName.Localization;
using Volo.Abp;

namespace MyCompanyName.MyProjectName;

[Authorize]
[Area(MyProjectNameRemoteServiceConsts.ModuleName)]
[RemoteService(Name = MyProjectNameRemoteServiceConsts.RemoteServiceName)]
[Route("api/MyProjectName/[controller]/[action]")]
public abstract class MyProjectNameController : AbpControllerBase
{
    protected MyProjectNameController()
    {
        LocalizationResource = typeof(MyProjectNameResource);
    }
}

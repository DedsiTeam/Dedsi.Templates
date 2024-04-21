using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace MyCompanyName.MyProjectName;

// [Authorize]
[Area(MyCompanyNameMyProjectNameCoreOptions.ModuleName)]
[RemoteService(Name = MyCompanyNameMyProjectNameCoreOptions.RemoteServiceName)]
[Route("api/MyProjectName/[controller]/[action]")]
public abstract class MyProjectNameController : AbpControllerBase
{

}
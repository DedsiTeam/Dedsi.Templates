using Microsoft.AspNetCore.Mvc;
using MyCompanyName.MyProjectName.AspNetCore;
using Volo.Abp;

namespace MyCompanyName.MyProjectName;

// [Authorize]
[Area(MyCompanyNameMyProjectNameCoreOptions.ModuleName)]
[RemoteService(Name = MyCompanyNameMyProjectNameCoreOptions.RemoteServiceName)]
[Route("api/MyProjectName/[controller]/[action]")]
public abstract class MyProjectNameController : MyCompanyNameMyProjectNameControllerBase
{

}
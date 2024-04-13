using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCompanyName.MyProjectName.Core;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace MyCompanyName.MyProjectName.HttpApi;

// [Authorize]
[Area(MyCompanyNameMyProjectNameCoreOptions.ModuleName)]
[RemoteService(Name = MyCompanyNameMyProjectNameCoreOptions.RemoteServiceName)]
[Route("api/MyProjectName/[controller]/[action]")]
public abstract class MyProjectNameController : AbpControllerBase
{

}
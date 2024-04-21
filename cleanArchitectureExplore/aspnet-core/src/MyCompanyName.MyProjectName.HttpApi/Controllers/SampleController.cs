using Microsoft.AspNetCore.Mvc;
using MyCompanyName.MyProjectName.HttpApi;
using MyCompanyName.MyProjectName.Samples;

namespace MyCompanyName.MyProjectName.Controllers;

public class SampleController(ISampleAppService sampleAppService,ISampleReadAppService sampleReadAppService) : MyProjectNameController
{
    /// <summary>
    /// 获得
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    public Task<SampleDto> GetAsync(Guid id) => sampleReadAppService.GetAsync(id);
}
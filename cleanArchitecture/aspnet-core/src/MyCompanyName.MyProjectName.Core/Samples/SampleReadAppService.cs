using MyCompanyName.MyProjectName.Core.Applications;

namespace MyCompanyName.MyProjectName.Samples;

public interface ISampleReadAppService
{
    Task<SampleDto> GetAsync();
}

public class SampleReadAppService : MyProjectNameAppService, ISampleReadAppService
{
    public Task<SampleDto> GetAsync()
    {
        return Task.FromResult(new SampleDto());
    }
}
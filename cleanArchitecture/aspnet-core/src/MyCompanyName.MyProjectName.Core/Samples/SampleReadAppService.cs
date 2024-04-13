using Mapster;
using MyCompanyName.MyProjectName.Core.Applications;

namespace MyCompanyName.MyProjectName.Samples;

public interface ISampleReadAppService
{
    Task<SampleDto> GetAsync(Guid id);
}

public class SampleReadAppService(ISampleRepository sampleRepository) : MyProjectNameAppService, ISampleReadAppService
{
    public async Task<SampleDto> GetAsync(Guid id)
    {
        var entity = await sampleRepository.GetAsync(a => a.Id == id);

        var resultDto = entity.Adapt<SampleDto>();
        
        return resultDto;
    }
}
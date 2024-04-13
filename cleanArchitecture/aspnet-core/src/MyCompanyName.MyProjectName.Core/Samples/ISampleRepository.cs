using Volo.Abp.Domain.Repositories;

namespace MyCompanyName.MyProjectName.Samples;

public interface ISampleRepository : IRepository<Sample, Guid>
{
    
}
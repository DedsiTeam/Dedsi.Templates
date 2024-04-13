using MyCompanyName.MyProjectName.Samples;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MyCompanyName.MyProjectName.EntityFrameworkCore.Repositories.Samples;

public class SampleRepository(IDbContextProvider<MyProjectNameDbContext> dbContextProvider)
    : EfCoreRepository<MyProjectNameDbContext, Sample, Guid>(dbContextProvider),
        ISampleRepository
{
    
}
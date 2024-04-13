using Volo.Abp.Domain.Entities;

namespace MyCompanyName.MyProjectName.Samples;

public class Sample : Entity<Guid>
{
    public string SampleName { get; set; }
}
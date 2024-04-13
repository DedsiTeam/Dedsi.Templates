using Volo.Abp.Application.Dtos;

namespace MyCompanyName.MyProjectName.Samples;

/// <summary>
/// 
/// </summary>
public class SampleDto : EntityDto<Guid>
{
    public string SampleName { get; set; }
}
using Mapster;
using MyCompanyName.MyProjectName.Core.AppServices;

namespace MyCompanyName.MyProjectName.AbpAuditLogs;

public class AbpAuditLogAppService(IAbpAuditLogRepository auditLogRepository) : MyCompanyNameMyProjectNameApplicationService
{
    public async Task<AbpAuditLogDto> GetAsync(Guid id)
    {
        var entity = await auditLogRepository.GetAsync(a => a.Id == id);

        return entity.Adapt<AbpAuditLogDto>();
    }

    public async Task<AbpAuditLogPagedResultDto> PagedListAsync(AbpAuditLogPagedInputDto input)
    {
        var dbData = await auditLogRepository.PagedListAsync(input);
        
        var items = dbData.Item2.Adapt<List<AbpAuditLogDto>>();

        return new AbpAuditLogPagedResultDto()
        {
            TotalCount = dbData.Item1,
            Items = items
        };
    }
}
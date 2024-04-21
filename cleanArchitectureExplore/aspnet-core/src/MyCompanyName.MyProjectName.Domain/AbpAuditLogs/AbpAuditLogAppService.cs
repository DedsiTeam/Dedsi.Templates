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
}
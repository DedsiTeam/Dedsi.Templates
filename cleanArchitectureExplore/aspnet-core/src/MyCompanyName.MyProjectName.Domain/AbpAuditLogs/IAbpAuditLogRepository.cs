using MyCompanyName.MyProjectName.Core.Repositories;

namespace MyCompanyName.MyProjectName.AbpAuditLogs;

public interface IAbpAuditLogRepository : IReadOnlyRepository<AbpAuditLog,Guid>
{
    
}
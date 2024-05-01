using MyCompanyName.MyProjectName.AbpAuditLogs;
using SqlSugar;

namespace MyCompanyName.MyProjectName.Repositories;

public class AbpAuditLogRepository(ISqlSugarClient sqlSugarClient) 
    : ReadOnlyRepository<AbpAuditLog,Guid>(sqlSugarClient), 
        IAbpAuditLogRepository
{
    
}
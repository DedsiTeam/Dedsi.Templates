using MyCompanyName.MyProjectName.AbpAuditLogs;
using SqlSugar;

namespace MyCompanyName.MyProjectName.Repositories;

public class AbpAuditLogRepository(ISqlSugarClient sqlSugarClient) 
    : ReadOnlyRepository<AbpAuditLog>(sqlSugarClient), 
        IAbpAuditLogRepository
{
    
}
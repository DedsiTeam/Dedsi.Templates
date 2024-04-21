using MyCompanyName.MyProjectName.Core.Domains;
using SqlSugar;

namespace MyCompanyName.MyProjectName.AbpAuditLogs;

[SugarTable("dbo.AbpAuditLogs")]
public class AbpAuditLog : EntityGuid
{
    public string ApplicationName { get; set; }
    
    public string Url { get; set; }
    
    public int HttpStatusCode { get; set; }
}
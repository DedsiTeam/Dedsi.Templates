using MyCompanyName.MyProjectName.Core.Domains;

namespace MyCompanyName.MyProjectName.AbpAuditLogs;

public class AbpAuditLogDto : EntityGuid
{
    public string ApplicationName { get; set; }
    
    public string Url { get; set; }
    
    public int HttpStatusCode { get; set; }
}
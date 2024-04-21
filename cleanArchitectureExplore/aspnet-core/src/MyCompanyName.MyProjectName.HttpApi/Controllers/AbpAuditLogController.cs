using Microsoft.AspNetCore.Mvc;
using MyCompanyName.MyProjectName.AbpAuditLogs;

namespace MyCompanyName.MyProjectName.Controllers;

public class AbpAuditLogController(AbpAuditLogAppService abpAuditLogAppService) : MyProjectNameController
{
    [HttpGet("{id}")]
    public Task<AbpAuditLogDto> GetAsync(Guid id) => abpAuditLogAppService.GetAsync(id);
}
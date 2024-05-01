using MyCompanyName.MyProjectName.Core.Domains;
using MyCompanyName.MyProjectName.Core.Repositories;

namespace MyCompanyName.MyProjectName.Core.AppServices;

public class CrudAppService<TEntity,TKey,TDto>(IRepository<TEntity,TKey> repository) 
    : MyCompanyNameMyProjectNameApplicationService
    where TEntity : class, IEntity<TKey>, new()
{


}
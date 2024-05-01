using Volo.Abp.DependencyInjection;

namespace MyCompanyName.MyProjectName.Core.Repositories;

public interface IRepository<TEntity, TKey> 
    : IBasicRepository<TEntity>,
        IReadOnlyRepository<TEntity, TKey>, 
        ITransientDependency 
    where TEntity : class, new()
{
    
}
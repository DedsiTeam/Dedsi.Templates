using System.Linq.Expressions;
using Volo.Abp.DependencyInjection;

namespace MyCompanyName.MyProjectName.Core.Repositories;

public interface IReadOnlyRepository<TEntity> : ITransientDependency
{
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
    
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
    
    Task<List<TEntity>> GetListAsync();
    
    Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression);
    
    Task<int> CountAsync();
    
    Task<int> CountAsync(Expression<Func<TEntity, bool>> expression);
}
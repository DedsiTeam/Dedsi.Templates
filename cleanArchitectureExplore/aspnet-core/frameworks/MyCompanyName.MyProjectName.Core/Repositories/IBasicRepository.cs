using System.Linq.Expressions;
using Volo.Abp.DependencyInjection;

namespace MyCompanyName.MyProjectName.Core.Repositories;

public interface IBasicRepository<TEntity> : ITransientDependency  where TEntity : class, new()
{
    Task<int> InsertAsync(TEntity entity);
    
    Task<int> InsertAsync(FormattableString sql);
    
    Task<int> InsertManyAsync(IEnumerable<TEntity> entities);

    Task<int> UpdateAsync(TEntity entity);
    
    Task<int> UpdateAsync(FormattableString sql);
    
    Task<int> DeleteAsync(TEntity entity);
    
    Task<int> DeleteAsync(FormattableString sql);
    
    Task<int> DeleteAsync(Expression<Func<TEntity, bool>> expression);
    
    Task<int> ExecuteCommandAsync(FormattableString sql);
}
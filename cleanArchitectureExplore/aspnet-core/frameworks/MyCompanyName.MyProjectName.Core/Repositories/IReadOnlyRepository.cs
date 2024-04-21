using System.Linq.Expressions;
using SqlSugar;
using Volo.Abp.DependencyInjection;

namespace MyCompanyName.MyProjectName.Core.Repositories;

public interface IReadOnlyRepository<TEntity> : ITransientDependency
{
    Task<ISqlSugarClient> GetSqlSugarClientAsync();
    Task<ISugarQueryable<TEntity>> GetQueryableAsync();
    
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
    
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
    
    Task<List<TEntity>> GetListAsync();
    
    Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression);


    Task<(int, List<TEntity>)> PagedListAsync(IPagedData pagedData);
    
    Task<(int, List<TEntity>)> PagedListAsync(
        int pageIndex,
        int pageSize,
        Expression<Func<TEntity, bool>> whereExpression,
        Expression<Func<TEntity, object>> orderExpression,
        OrderByType orderByType = OrderByType.Asc);
    
    Task<int> CountAsync();
    
    Task<int> CountAsync(Expression<Func<TEntity, bool>> expression);
}
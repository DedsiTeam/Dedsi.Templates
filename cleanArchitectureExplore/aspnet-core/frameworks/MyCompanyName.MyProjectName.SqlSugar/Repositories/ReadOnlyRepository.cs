using System.Linq.Expressions;
using MyCompanyName.MyProjectName.Core.Repositories;
using SqlSugar;

namespace MyCompanyName.MyProjectName.Repositories;

public class ReadOnlyRepository<TEntity>(ISqlSugarClient sqlSugarClient) : IReadOnlyRepository<TEntity>
{
    protected ISugarQueryable<TEntity> GetQueryable() => sqlSugarClient.Queryable<TEntity>();
    
    public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
    {
        return GetQueryable().AnyAsync(expression);
    }

    public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        return GetQueryable().FirstAsync(expression);
    }

    public Task<List<TEntity>> GetListAsync()
    {
        return GetQueryable().ToListAsync();
    }

    public Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression)
    {
        return GetQueryable().Where(expression).ToListAsync();
    }

    public Task<int> CountAsync()
    {
        return GetQueryable().CountAsync();
    }

    public Task<int> CountAsync(Expression<Func<TEntity, bool>> expression)
    {
        return GetQueryable().CountAsync(expression);
    }

}


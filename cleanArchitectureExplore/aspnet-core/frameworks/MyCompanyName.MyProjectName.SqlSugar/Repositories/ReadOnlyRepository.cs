using System.Linq.Expressions;
using MyCompanyName.MyProjectName.Core.Repositories;
using SqlSugar;

namespace MyCompanyName.MyProjectName.Repositories;

public class ReadOnlyRepository<TEntity,TKey>(ISqlSugarClient sqlSugarClient) : IReadOnlyRepository<TEntity,TKey>
{
    public Task<ISqlSugarClient> GetSqlSugarClientAsync() => Task.FromResult(sqlSugarClient);
    public Task<ISugarQueryable<TEntity>> GetQueryableAsync() => Task.FromResult(sqlSugarClient.Queryable<TEntity>());
    
    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await (await GetQueryableAsync()).AnyAsync(expression);
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await (await GetQueryableAsync()).FirstAsync(expression);
    }

    public async Task<TEntity> GetAsync(TKey id)
    {
        return await (await GetQueryableAsync()).InSingleAsync(id);
    }

    public async Task<List<TEntity>> GetListAsync()
    {
        return await (await GetQueryableAsync()).ToListAsync();
    }

    public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await (await GetQueryableAsync()).Where(expression).ToListAsync();
    }

    public async Task<(int, List<TEntity>)> PagedListAsync(IPagedData pagedData)
    {
        RefAsync<int> totalNumber = 0;
        var entities = await (await GetQueryableAsync()).ToPageListAsync(pagedData.PageIndex, pagedData.PageSize,totalNumber);
        return (totalNumber, entities);
    }

    public async Task<(int,List<TEntity>)> PagedListAsync(
        int pageIndex, 
        int pageSize, 
        Expression<Func<TEntity, bool>> whereExpression, 
        Expression<Func<TEntity, object>> orderExpression, 
        OrderByType orderByType = OrderByType.Asc)
    {
        RefAsync<int> totalNumber = 0;
        var entities = await (await GetQueryableAsync())
                                            .Where(whereExpression)
                                            .OrderBy(orderExpression, orderByType)
                                            .ToPageListAsync(pageIndex, pageSize,totalNumber);
        
        return (totalNumber, entities);
    }

    public async Task<int> CountAsync()
    {
        return await (await GetQueryableAsync()).CountAsync();
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await (await GetQueryableAsync()).CountAsync(expression);
    }

}


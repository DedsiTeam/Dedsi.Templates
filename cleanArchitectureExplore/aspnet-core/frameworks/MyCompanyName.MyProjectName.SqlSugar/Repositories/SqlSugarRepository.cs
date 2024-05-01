using System.Linq.Expressions;
using MyCompanyName.MyProjectName.Core.Repositories;
using SqlSugar;

namespace MyCompanyName.MyProjectName.Repositories;

public class SqlSugarRepository<TEntity,TKey>(ISqlSugarClient sqlSugarClient) 
    : ReadOnlyRepository<TEntity,TKey>(sqlSugarClient), 
        IRepository<TEntity,TKey>  
    where TEntity : class, new()
{
    public Task<int> InsertAsync(TEntity entity)
    {
        return sqlSugarClient.Insertable(entity).ExecuteCommandAsync();
    }

    public Task<int> InsertAsync(FormattableString sql)
    {
        throw new NotImplementedException();
    }

    public Task<int> InsertManyAsync(IEnumerable<TEntity> entities)
    {
        return sqlSugarClient.Insertable<TEntity>(entities).ExecuteCommandAsync();
    }

    public Task<int> UpdateAsync(TEntity entity)
    {
        return sqlSugarClient.Updateable(entity).ExecuteCommandAsync();
    }

    public Task<int> UpdateAsync(FormattableString sql)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(TEntity entity)
    {
        return sqlSugarClient.Deleteable(entity).ExecuteCommandAsync();
    }

    public Task<int> DeleteAsync(FormattableString sql)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(Expression<Func<TEntity, bool>> expression)
    {
        return sqlSugarClient.Deleteable<TEntity>().Where(expression).ExecuteCommandAsync();
    }

    public Task<int> ExecuteCommandAsync(FormattableString sql)
    {
        throw new NotImplementedException();
    }
}
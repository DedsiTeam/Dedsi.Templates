namespace MyCompanyName.MyProjectName.Core.Repositories;

public interface IRepository<TEntity> : IBasicRepository<TEntity>,IReadOnlyRepository<TEntity> where TEntity : class, new()
{
    
}
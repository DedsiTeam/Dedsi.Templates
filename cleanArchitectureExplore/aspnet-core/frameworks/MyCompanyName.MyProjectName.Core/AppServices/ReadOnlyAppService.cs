using Mapster;
using MyCompanyName.MyProjectName.Core.Repositories;

namespace MyCompanyName.MyProjectName.Core.AppServices;

public class ReadOnlyAppService<TEntity,TKey,TDto>(IReadOnlyRepository<TEntity,TKey> repository) 
{
    public virtual async Task<TDto> GetAsync(TKey id)
    {
        var entity = await GetEntityByIdAsync(id);

        return await MapToDtoAsync(entity);
    }
    
    protected virtual async Task<TEntity> GetEntityByIdAsync(TKey id)
    {
        return await repository.GetAsync(id);
    }

    protected virtual Task<TDto> MapToDtoAsync(TEntity entity) => Task.FromResult(MapToDto(entity));
    
    protected virtual Task<TEntity> MapToEntityAsync(TDto dto) => Task.FromResult(MapToEntity(dto));
    
    protected virtual TDto MapToDto(TEntity entity)
    {
        return entity.Adapt<TDto>();
    }
    
    protected virtual TEntity MapToEntity(TDto dto)
    {
        return dto.Adapt<TEntity>();
    }
    
}
namespace MyCompanyName.MyProjectName.Core.AppServices;

public class EntityDto<TKey> : IEntityDto<TKey>
{
    public virtual TKey Id { get; set; }
}

public class EntityDtoGuid : EntityDto<Guid>;
public class EntityDtoLong : EntityDto<long>;
public class EntityDtoString : EntityDto<string>;

public class PagedInputDto : IPagedInputDto
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}

public class PagedResultDto<T>
{
    public long TotalCount { get; set; }
    
    public IReadOnlyList<T> Items { get; set; }
}
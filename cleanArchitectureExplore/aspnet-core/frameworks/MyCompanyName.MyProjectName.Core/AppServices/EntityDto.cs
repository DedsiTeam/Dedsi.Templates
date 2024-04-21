namespace MyCompanyName.MyProjectName.Core.AppServices;

public class EntityDto<TKey>
{
    public virtual TKey Id { get; set; }
}

public class EntityDtoGuid : EntityDto<Guid>;
public class EntityDtoLong : EntityDto<long>;
public class EntityDtoString : EntityDto<string>;
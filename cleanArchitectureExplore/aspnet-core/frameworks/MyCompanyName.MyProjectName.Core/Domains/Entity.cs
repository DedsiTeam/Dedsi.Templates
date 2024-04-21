using SqlSugar;

namespace MyCompanyName.MyProjectName.Core.Domains;

public class Entity<TKey>
{
    [SugarColumn(IsPrimaryKey = true)]
    public virtual TKey Id { get; set; }
}

public class EntityGuid : Entity<Guid>;
public class EntityLong : Entity<long>;
public class EntityString : Entity<string>;
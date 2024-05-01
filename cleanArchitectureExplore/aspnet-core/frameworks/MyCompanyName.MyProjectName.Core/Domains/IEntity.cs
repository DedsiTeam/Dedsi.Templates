namespace MyCompanyName.MyProjectName.Core.Domains;

public interface IEntity<TKey>
{
    TKey Id { get; set; }
}
using MyCompanyName.MyProjectName.Core.Repositories;

namespace MyCompanyName.MyProjectName.Core.AppServices;

public interface IEntityDto<TKey>
{
    TKey Id { get; set; }
}

public interface IPagedInputDto : IPagedData;
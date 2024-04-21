namespace MyCompanyName.MyProjectName.Core.Repositories;

public interface IPagedData
{
    int PageIndex { get; set; }
    int PageSize { get; set; }
}
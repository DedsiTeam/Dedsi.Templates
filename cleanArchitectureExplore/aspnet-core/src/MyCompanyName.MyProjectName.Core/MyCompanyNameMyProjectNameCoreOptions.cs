namespace MyCompanyName.MyProjectName.Core;

public class MyCompanyNameMyProjectNameCoreOptions
{
    public const string RemoteServiceName = "MyProjectName";

    public const string ModuleName = "myProjectName";
    
    public static string DbTablePrefix { get; set; } = "MyProjectName";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "MyProjectNameDB";
    
}
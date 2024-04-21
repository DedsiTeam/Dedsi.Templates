using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using Volo.Abp.Modularity;

namespace MyCompanyName.MyProjectName.Extensions;

/// <summary>
/// RTAsset SqlSugar 扩展
/// </summary>
public static class RTAssetSqlSugarExtensions
{
    public static void ConfigureSqlSugar(this ServiceConfigurationContext context,string connectionStringName)
    {
        var configuration = context.Services.GetConfiguration();
        var connectionString = configuration.GetConnectionString(connectionStringName);

        var connectionConfig = new ConnectionConfig()
        {
            DbType = DbType.SqlServer,
            ConnectionString = connectionString,
            IsAutoCloseConnection = true,
        };
        context.ConfigureSqlSugar(connectionConfig);
    }

    public static void ConfigureSqlSugar(this ServiceConfigurationContext context, ConnectionConfig connectionConfig, string environmentName = "Localhost")
    {
        var environment = context.Services.GetHostingEnvironment();

        context.Services.AddScoped<ISqlSugarClient>(s =>
        {
            var sqlSugarClient = new SqlSugarClient(connectionConfig);

            // 本地研发环境才会开启
            if (environment.EnvironmentName == environmentName)
            {
                sqlSugarClient.Aop.OnLogExecuting = (sql, parameters) =>
                {
                    Console.WriteLine(environmentName + "：============================================================   Start");
                    Console.WriteLine(UtilMethods.GetSqlString(connectionConfig.DbType, sql, parameters));
                    Console.WriteLine(environmentName + "：============================================================   End");
                };
            }

            return sqlSugarClient;
        });
    }
    
}
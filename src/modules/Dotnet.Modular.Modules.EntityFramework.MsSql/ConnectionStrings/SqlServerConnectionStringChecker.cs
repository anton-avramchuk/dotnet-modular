using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.Data;
using Dotnet.Modular.Modules.Data.Abstractions;
using Microsoft.Data.SqlClient;

namespace Dotnet.Modular.Modules.EntityFramework.MsSql.ConnectionStrings;

//[Dependency(ReplaceServices = true)]
[Export(ExportType.Trancient,typeof(IConnectionStringChecker))]
public class SqlServerConnectionStringChecker : IConnectionStringChecker
{
    public virtual async Task<ConnectionStringCheckResult> CheckAsync(string connectionString)
    {
        var result = new ConnectionStringCheckResult();
        var connString = new SqlConnectionStringBuilder(connectionString)
        {
            ConnectTimeout = 1
        };

        var oldDatabaseName = connString.InitialCatalog;
        connString.InitialCatalog = "master";

        try
        {
            await using var conn = new SqlConnection(connString.ConnectionString);
            await conn.OpenAsync();
            result.Connected = true;
            await conn.ChangeDatabaseAsync(oldDatabaseName);
            result.DatabaseExists = true;

            await conn.CloseAsync();

            return result;
        }
        catch (Exception e)
        {
            return result;
        }
    }
}

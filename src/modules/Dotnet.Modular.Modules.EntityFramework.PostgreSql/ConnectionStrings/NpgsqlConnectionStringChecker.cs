using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.Data;
using Dotnet.Modular.Modules.Data.Abstractions;
using Npgsql;

namespace Dotnet.Modular.Modules.EntityFramework.PostgreSql.ConnectionStrings;

[Export(ExportType.Trancient, typeof(IConnectionStringChecker))]
public class NpgsqlConnectionStringChecker : IConnectionStringChecker
{
    public virtual async Task<ConnectionStringCheckResult> CheckAsync(string connectionString)
    {
        var result = new ConnectionStringCheckResult();
        var connString = new NpgsqlConnectionStringBuilder(connectionString)
        {
            Timeout = 1
        };

        var oldDatabaseName = connString.Database;
        connString.Database = "postgres";

        try
        {
            await using var conn = new NpgsqlConnection(connString.ConnectionString);
            await conn.OpenAsync();
            result.Connected = true;
            await conn.ChangeDatabaseAsync(oldDatabaseName!);
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

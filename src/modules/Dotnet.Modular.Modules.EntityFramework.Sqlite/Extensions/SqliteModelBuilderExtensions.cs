using Microsoft.EntityFrameworkCore;

namespace Dotnet.Modular.Modules.EntityFramework.Sqlite.Extensions;

public static class SqliteModelBuilderExtensions
{
    public static void UseSqlite(
        this ModelBuilder modelBuilder)
    {
        //modelBuilder.SetDatabaseProvider(EfCoreDatabaseProvider.Sqlite);
    }
}

using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Dotnet.Modular.Modules.EntityFramework.Sqlite.Extensions;

public static class DbContextOptionsSqliteExtensions
{
    public static void UseSqlite(
        this DataContextOptions options,
        Action<SqliteDbContextOptionsBuilder>? sqliteOptionsAction = null)
    {
        options.Configure(context =>
        {
            context.UseSqlite(sqliteOptionsAction);
        });
    }

    public static void UseSqlite<TDbContext>(
        this DataContextOptions options,
        Action<SqliteDbContextOptionsBuilder>? sqliteOptionsAction = null)
        where TDbContext : DataContext<TDbContext>
    {
        options.Configure<TDbContext>(context =>
        {
            context.UseSqlite(sqliteOptionsAction);
        });
    }
}

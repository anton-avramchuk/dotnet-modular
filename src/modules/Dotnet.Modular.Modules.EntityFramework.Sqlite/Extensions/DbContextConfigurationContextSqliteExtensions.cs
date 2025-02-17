using Dotnet.Modular.Modules.EntityFramework.Sqlite.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data.Common;

namespace Dotnet.Modular.Modules.EntityFramework.Sqlite.Extensions;

public static class DbContextConfigurationContextSqliteExtensions
{
    public static DbContextOptionsBuilder UseSqlite(
        this DataContextConfigurationContext context,
        Action<SqliteDbContextOptionsBuilder>? sqliteOptionsAction = null)
    {
        if (context.ExistingConnection != null)
        {
            return context.DbContextOptions.UseSqlite(context.ExistingConnection, optionsBuilder =>
            {
                optionsBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                sqliteOptionsAction?.Invoke(optionsBuilder);
            });
        }
        else
        {
            return context.DbContextOptions.UseSqlite(context.ConnectionString, optionsBuilder =>
            {
                optionsBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                sqliteOptionsAction?.Invoke(optionsBuilder);
            });
        }
    }

    public static DbContextOptionsBuilder UseSqlite(
        this DataContextConfigurationContext context,
        DbConnection connection,
        Action<SqliteDbContextOptionsBuilder>? sqliteOptionsAction = null)
    {
        if (context.ExistingConnection != null)
        {
            return context.DbContextOptions.UseSqlite(context.ExistingConnection, optionsBuilder =>
            {
                optionsBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                sqliteOptionsAction?.Invoke(optionsBuilder);
            });
        }
        else
        {
            return context.DbContextOptions.UseSqlite(connection, optionsBuilder =>
            {
                optionsBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                sqliteOptionsAction?.Invoke(optionsBuilder);
            });
        }
    }
}

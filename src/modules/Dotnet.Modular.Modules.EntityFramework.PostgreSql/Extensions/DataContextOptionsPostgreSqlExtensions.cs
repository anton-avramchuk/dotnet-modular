using Dotnet.Modular.Modules.EntityFramework;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace Dotnet.Modular.Modules.EntityFramework.PostgreSql.Extensions;

public static class DataContextOptionsPostgreSqlExtensions
{
    [Obsolete("Use 'UseNpgsql(...)' method instead. This will be removed in future versions.")]
    public static void UsePostgreSql(
        this DataContextOptions options,
        Action<NpgsqlDbContextOptionsBuilder>? postgreSqlOptionsAction = null)
    {
        options.Configure(context =>
        {
            context.UseNpgsql(postgreSqlOptionsAction);
        });
    }

    [Obsolete("Use 'UseNpgsql(...)' method instead. This will be removed in future versions.")]
    public static void UsePostgreSql<TDbContext>(
        this DataContextOptions options,
        Action<NpgsqlDbContextOptionsBuilder>? postgreSqlOptionsAction = null)
        where TDbContext : DataContext<TDbContext>
    {
        options.Configure<TDbContext>(context =>
        {
            context.UseNpgsql(postgreSqlOptionsAction);
        });
    }

    public static void UseNpgsql(
        this DataContextOptions options,
        Action<NpgsqlDbContextOptionsBuilder>? postgreSqlOptionsAction = null)
    {
        options.Configure(context =>
        {
            context.UseNpgsql(postgreSqlOptionsAction);
        });
    }

    public static void UseNpgsql<TDbContext>(
        this DataContextOptions options,
        Action<NpgsqlDbContextOptionsBuilder>? postgreSqlOptionsAction = null)
        where TDbContext : DataContext<TDbContext>
    {
        options.Configure<TDbContext>(context =>
        {
            context.UseNpgsql(postgreSqlOptionsAction);
        });
    }
}

using Dotnet.Modular.Modules.EntityFramework;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Crm.DataAccess.EntityFramework.MsSql.Extensions;

public static class DataContextOptionsSqlServerExtensions
{
    public static void UseSqlServer(
        this DataContextOptions options,
        Action<SqlServerDbContextOptionsBuilder>? sqlServerOptionsAction = null)
    {
        options.Configure(context =>
        {
            context.UseSqlServer(sqlServerOptionsAction);
        });
    }

    public static void UseSqlServer<TDbContext>(
        this DataContextOptions options,
        Action<SqlServerDbContextOptionsBuilder>? sqlServerOptionsAction = null)
        where TDbContext : DataContext<TDbContext>
    {
        options.Configure<TDbContext>(context =>
        {
            context.UseSqlServer(sqlServerOptionsAction);
        });
    }
}

using Crm.DataAccess.EntityFramework;
using Crm.DataAccess.EntityFramework.PostgreSql.Extensions;
using Dotnet.Modular.Modules.EntityFramework.PostgreSql.Extensions;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace Dotnet.Modular.Modules.EntityFramework.PostgreSql.Extensions;

public static class DataContextConfigurationContextPostgreSqlExtensions
{
    public static DbContextOptionsBuilder UseNpgsql(
        this DataContextConfigurationContext context,
        Action<NpgsqlDbContextOptionsBuilder>? postgreSqlOptionsAction = null)
    {
        if (context.ExistingConnection != null)
        {
            return context.DbContextOptions.UseNpgsql(context.ExistingConnection, optionsBuilder =>
            {
                optionsBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                postgreSqlOptionsAction?.Invoke(optionsBuilder);
            });
        }
        else
        {
            return context.DbContextOptions.UseNpgsql(context.ConnectionString, optionsBuilder =>
            {
                optionsBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                postgreSqlOptionsAction?.Invoke(optionsBuilder);
            });
        }
    }
}

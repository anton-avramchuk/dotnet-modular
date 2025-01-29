using Crm.DataAccess.EntityFramework.MsSql.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Crm.DataAccess.EntityFramework.MsSql.Extensions;

public static class DataContextConfigurationContextSqlServerExtensions
{
    public static DbContextOptionsBuilder UseSqlServer(
        this DataContextConfigurationContext context,
        Action<SqlServerDbContextOptionsBuilder>? sqlServerOptionsAction = null)
    {
        if (context.ExistingConnection != null)
        {
            return context.DbContextOptions.UseSqlServer(context.ExistingConnection, optionsBuilder =>
            {
                optionsBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                sqlServerOptionsAction?.Invoke(optionsBuilder);
            });
        }
        else
        {
            return context.DbContextOptions.UseSqlServer(context.ConnectionString, optionsBuilder =>
            {
                optionsBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                sqlServerOptionsAction?.Invoke(optionsBuilder);
            });
        }
    }
}

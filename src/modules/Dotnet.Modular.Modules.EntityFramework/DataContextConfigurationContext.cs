using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Data.Common;

namespace Crm.DataAccess.EntityFramework;

public class DataContextConfigurationContext : IServiceProviderAccessor
{
    public IServiceProvider ServiceProvider { get; }

    public string ConnectionString { get; }

    public string ConnectionStringName { get; }

    public DbConnection ExistingConnection { get; }

    public DbContextOptionsBuilder DbContextOptions { get; protected set; }

    public DataContextConfigurationContext(
        string connectionString,
        IServiceProvider serviceProvider,
        string connectionStringName,
        DbConnection existingConnection)
    {
        ConnectionString = connectionString;
        ServiceProvider = serviceProvider;
        ConnectionStringName = connectionStringName;
        ExistingConnection = existingConnection;

        DbContextOptions = new DbContextOptionsBuilder()
            .UseLoggerFactory(serviceProvider.GetRequiredService<ILoggerFactory>())
            .UseApplicationServiceProvider(serviceProvider);
    }
}

public class ApplicationDbContextConfigurationContext<TDbContext> : DataContextConfigurationContext
    where TDbContext : DbContext, IDataContext
{
    public new DbContextOptionsBuilder<TDbContext> DbContextOptions => (DbContextOptionsBuilder<TDbContext>)base.DbContextOptions;

    public ApplicationDbContextConfigurationContext(string connectionString, IServiceProvider serviceProvider, string connectionStringName, DbConnection existingConnection) : base(connectionString, serviceProvider, connectionStringName, existingConnection)
    {
        base.DbContextOptions = new DbContextOptionsBuilder<TDbContext>()
            .UseLoggerFactory(serviceProvider.GetRequiredService<ILoggerFactory>())
            .UseApplicationServiceProvider(serviceProvider); ;
    }
}

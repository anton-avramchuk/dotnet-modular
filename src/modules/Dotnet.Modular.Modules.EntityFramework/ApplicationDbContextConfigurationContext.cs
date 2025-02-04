using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Data.Common;

namespace Dotnet.Modular.Modules.EntityFramework;

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

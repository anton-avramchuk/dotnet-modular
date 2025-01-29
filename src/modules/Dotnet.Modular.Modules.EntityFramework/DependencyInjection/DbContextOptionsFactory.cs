using Dotnet.Modular.Modules.Data.Abstractions;
using Dotnet.Modular.Modules.Data.Attributes;
using Dotnet.Modular.Modules.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Crm.DataAccess.EntityFramework.DependencyInjection;

public static class DbContextOptionsFactory
{
    public static DbContextOptions<TDbContext> Create<TDbContext>(IServiceProvider serviceProvider)
        where TDbContext : DbContext, IDataContext
    {
        var creationContext = GetCreationContext<TDbContext>(serviceProvider);

        var context = new ApplicationDbContextConfigurationContext<TDbContext>(
            creationContext.ConnectionString,
            serviceProvider,
            creationContext.ConnectionStringName,
            creationContext.ExistingConnection
        );

        var options = GetDbContextOptions<TDbContext>(serviceProvider);

        //PreConfigure(options, context);
        Configure(options, context);

        return context.DbContextOptions.Options;
    }

    private static DataContextOptions GetDbContextOptions<TDbContext>(IServiceProvider serviceProvider)
        where TDbContext : DbContext, IDataContext
    {
        return serviceProvider.GetRequiredService<IOptions<DataContextOptions>>().Value;
    }

    private static DataContextCreationContext GetCreationContext<TDbContext>(IServiceProvider serviceProvider)
        where TDbContext : DbContext, IDataContext
    {
        var context = DataContextCreationContext.Current;
        if (context != null)
        {
            return context;
        }

        var connectionStringName = ConnectionStringNameAttribute.GetConnStringName<TDbContext>();
        var connectionString = ResolveConnectionString<TDbContext>(serviceProvider, connectionStringName);

        return new DataContextCreationContext(
            connectionStringName,
            connectionString
        );
    }

    private static void Configure<TDbContext>(
        DataContextOptions options,
        ApplicationDbContextConfigurationContext<TDbContext> context)
        where TDbContext : DbContext, IDataContext
    {
        var configureAction = options.ConfigureActions.GetOrDefault(typeof(TDbContext));
        if (configureAction != null)
        {
            ((Action<ApplicationDbContextConfigurationContext<TDbContext>>)configureAction).Invoke(context);
        }
        else if (options.DefaultConfigureAction != null)
        {
            options.DefaultConfigureAction.Invoke(context);
        }
        else
        {
            throw new Exception(
                $"No configuration found for {typeof(DbContext).AssemblyQualifiedName}! Use services.Configure<CrmDbContextOptions>(...) to configure it.");
        }
    }

    private static string ResolveConnectionString<TDbContext>(
        IServiceProvider serviceProvider,
        string connectionStringName)
    {
        // Use DefaultConnectionStringResolver.Resolve when we remove IConnectionStringResolver.Resolve
        var connectionStringResolver = serviceProvider.GetRequiredService<IConnectionStringResolver>();
        //        var currentTenant = serviceProvider.GetRequiredService<ICurrentTenant>();

        //// Multi-tenancy unaware contexts should always use the host connection string
        //if (typeof(TDbContext).IsDefined(typeof(IgnoreMultiTenancyAttribute), false))
        //{
        //    using (currentTenant.Change(null))
        //    {
        //        return connectionStringResolver.Resolve(connectionStringName);
        //    }
        //}

        return connectionStringResolver.ResolveAsync(connectionStringName).Result;
    }

}
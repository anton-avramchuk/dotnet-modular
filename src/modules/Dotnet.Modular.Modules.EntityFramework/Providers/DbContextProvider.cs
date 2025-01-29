using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.Data.Abstractions;
using Dotnet.Modular.Modules.Data.Attributes;
using Dotnet.Modular.Modules.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Crm.DataAccess.EntityFramework.Providers;

public class DbContextProvider<TDbContext> : IDbContextProvider<TDbContext>, IServiceProviderAccessor
    where TDbContext : IDataContext
{
    private readonly IConnectionStringResolver _connectionStringResolver;
    private readonly DataContextOptions _options;

    public TDbContext GetDbContext()
    {
        var targetDbContextType = _options.GetReplacedTypeOrSelf(typeof(TDbContext));
        var connectionStringName = ConnectionStringNameAttribute.GetConnStringName(targetDbContextType);
        var connectionString = ResolveConnectionString(connectionStringName);
        return CreateDbContext(connectionStringName, connectionString);
    }

    public async Task<TDbContext> GetDbContextAsync()
    {
        var targetDbContextType = _options.GetReplacedTypeOrSelf(typeof(TDbContext));
        var connectionStringName = ConnectionStringNameAttribute.GetConnStringName(targetDbContextType);
        var connectionString = await ResolveConnectionStringAsync(connectionStringName);
        return await CreateDbContextAsync(connectionStringName, connectionString);
    }

    private string ResolveConnectionString(string connectionStringName)
    {
        return _connectionStringResolver.ResolveAsync(connectionStringName).Result;
    }

    private async Task<string> ResolveConnectionStringAsync(string connectionStringName)
    {
        return await _connectionStringResolver.ResolveAsync(connectionStringName);
    }

    private TDbContext CreateDbContext(string connectionStringName, string connectionString)
    {
        var creationContext = new DataContextCreationContext(connectionStringName, connectionString);
        using (DataContextCreationContext.Use(creationContext))
        {
            var dbContext = CreateDbContext();

            return dbContext;
        }
    }

    private TDbContext CreateDbContext()
    {
        return ServiceProvider.GetRequiredService<TDbContext>();
    }

    private async Task<TDbContext> CreateDbContextAsync(string connectionStringName, string connectionString)
    {
        var creationContext = new DataContextCreationContext(connectionStringName, connectionString);
        using (DataContextCreationContext.Use(creationContext))
        {
            var dbContext = await CreateDbContextAsync();


            return dbContext;
        }
    }

    private Task<TDbContext> CreateDbContextAsync()
    {
        return Task.FromResult(ServiceProvider.GetRequiredService<TDbContext>());
    }

    public IServiceProvider ServiceProvider { get; }

    public DbContextProvider(IServiceProvider serviceProvider, IConnectionStringResolver connectionStringResolver, IOptions<DataContextOptions> options)
    {
        if (options == null) throw new ArgumentNullException(nameof(options));
        _connectionStringResolver = connectionStringResolver ?? throw new ArgumentNullException(nameof(connectionStringResolver));
        ServiceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        _options = options.Value;
    }
}
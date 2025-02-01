using System.Reflection;
using Dotnet.Modular.Modules.EntityFramework.Attributes;
using Dotnet.Modular.Modules.EntityFramework.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Dotnet.Modular.Modules.EntityFramework.Extensions.Services;

public static class EfCoreServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationDbContext<TDbContext>(
        this IServiceCollection services,
        Action<IApplicationDbContextRegistrationOptionsBuilder> optionsBuilder = null)
        where TDbContext : DbContext, IDataContext
    {
        //services.AddMemoryCache();

        var options = new ApplicationDbContextRegistrationOptions(typeof(TDbContext), services);

        var replacedDbContextTypes = typeof(TDbContext).GetCustomAttributes<ReplaceDbContextAttribute>(true)
            .SelectMany(x => x.ReplacedDbContextTypes).ToList();

        foreach (var dbContextType in replacedDbContextTypes)
        {
            options.ReplaceDbContext(dbContextType);
        }

        optionsBuilder?.Invoke(options);
        services.TryAddScoped(DbContextOptionsFactory.Create<TDbContext>);

        foreach (var entry in options.ReplacedDbContextTypes)
        {
            var originalDbContextType = entry.Key;
            var targetDbContextType = entry.Value ?? typeof(TDbContext);

            services.Replace(
                ServiceDescriptor.Scoped(
                    originalDbContextType,
                    sp => sp.GetRequiredService(targetDbContextType)
                )
            );

            services.Configure<DataContextOptions>(opts =>
            {
                opts.DbContextReplacements[originalDbContextType] = targetDbContextType;
            });
        }

        //new EfCoreRepositoryRegistrar(options).AddRepositories();

        return services;
    }


}
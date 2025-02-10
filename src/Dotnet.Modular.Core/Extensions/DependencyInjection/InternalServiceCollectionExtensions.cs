using Dotnet.Modular.Core.Abstractions;
using Dotnet.Modular.Core.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace Dotnet.Modular.Core.Extensions.DependencyInjection;

internal static class InternalServiceCollectionExtensions
{
    internal static void AddCoreServices(this IServiceCollection services)
    {
        services.AddOptions();
        services.AddLogging();
    }

    internal static void AddCoreCrmServices(this IServiceCollection services,
        ICrmApplication crmApplication,
        CrmApplicationCreationOptions applicationCreationOptions)
    {
        var moduleLoader = new ModuleLoader();
        var assemblyFinder = new AssemblyFinder(crmApplication);
        var typeFinder = new TypeFinder(assemblyFinder);

        //if (!services.IsAdded<IConfiguration>())
        //{
        //    services.ReplaceConfiguration(
        //        ConfigurationHelper.BuildConfiguration(
        //            applicationCreationOptions.Configuration
        //        )
        //    );
        //}

        services.TryAddSingleton<IModuleLoader>(moduleLoader);
        services.TryAddSingleton<IAssemblyFinder>(assemblyFinder);
        services.TryAddSingleton<ITypeFinder>(typeFinder);
        services.TryAddSingleton<IInitLoggerFactory>(new DefaultInitLoggerFactory());

        //services.AddAssemblyOf<ICrmApplication>();

        //services.AddTransient(typeof(ISimpleStateCheckerManager<>), typeof(SimpleStateCheckerManager<>));

        services.Configure<CrmModuleLifecycleOptions>(options =>
        {
            options.Contributors.Add<OnPreApplicationInitializationModuleLifecycleContributor>();
            options.Contributors.Add<OnApplicationInitializationModuleLifecycleContributor>();
            options.Contributors.Add<OnPostApplicationInitializationModuleLifecycleContributor>();
            options.Contributors.Add<OnApplicationShutdownModuleLifecycleContributor>();
        });
    }
}

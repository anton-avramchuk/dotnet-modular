using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Dotnet.Modular.Core;

public static class CrmApplicationFactory
{
    public async static Task<ICrmApplicationWithInternalServiceProvider> CreateAsync<TStartupModule>(
        Action<CrmApplicationCreationOptions>? optionsAction = null)
        where TStartupModule : IModule
    {
        var app = Create(typeof(TStartupModule), options =>
        {
            options.SkipConfigureServices = true;
            optionsAction?.Invoke(options);
        });
        await app.ConfigureServicesAsync();
        return app;
    }

    public async static Task<ICrmApplicationWithInternalServiceProvider> CreateAsync(
         Type startupModuleType,
        Action<CrmApplicationCreationOptions>? optionsAction = null)
    {
        throw new NotImplementedException();

        //var app = new CrmApplicationWithInternalServiceProvider(startupModuleType, options =>
        //{
        //    options.SkipConfigureServices = true;
        //    optionsAction?.Invoke(options);
        //});
        //await app.ConfigureServicesAsync();
        //return app;
    }

    public async static Task<ICrmApplicationWithExternalServiceProvider> CreateAsync<TStartupModule>(
         IServiceCollection services,
        Action<CrmApplicationCreationOptions>? optionsAction = null)
        where TStartupModule : IModule
    {
        var app = Create(typeof(TStartupModule), services, options =>
        {
            options.SkipConfigureServices = true;
            optionsAction?.Invoke(options);
        });
        await app.ConfigureServicesAsync();
        return app;
    }

    public async static Task<ICrmApplicationWithExternalServiceProvider> CreateAsync(
         Type startupModuleType,
         IServiceCollection services,
        Action<CrmApplicationCreationOptions>? optionsAction = null)
    {

        throw new NotImplementedException();
        //var app = new CrmApplicationWithExternalServiceProvider(startupModuleType, services, options =>
        //{
        //    options.SkipConfigureServices = true;
        //    optionsAction?.Invoke(options);
        //});
        //await app.ConfigureServicesAsync();
        //return app;
    }

    public static ICrmApplicationWithInternalServiceProvider Create<TStartupModule>(
        Action<CrmApplicationCreationOptions>? optionsAction = null)
        where TStartupModule : IModule
    {
        return Create(typeof(TStartupModule), optionsAction);
    }

    public static ICrmApplicationWithInternalServiceProvider Create(
         Type startupModuleType,
        Action<CrmApplicationCreationOptions>? optionsAction = null)
    {
        throw new NotImplementedException();
        //return new CrmApplicationWithInternalServiceProvider(startupModuleType, optionsAction);
    }

    public static ICrmApplicationWithExternalServiceProvider Create<TStartupModule>(
         IServiceCollection services,
        Action<CrmApplicationCreationOptions>? optionsAction = null)
        where TStartupModule : IModule
    {
        return Create(typeof(TStartupModule), services, optionsAction);
    }

    public static ICrmApplicationWithExternalServiceProvider Create(
         Type startupModuleType,
         IServiceCollection services,
        Action<CrmApplicationCreationOptions>? optionsAction = null)
    {
        throw new NotImplementedException();
        //return new CrmApplicationWithExternalServiceProvider(startupModuleType, services, optionsAction);
    }
}

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Dotnet.Modular.Core.Extensions.DependencyInjection;

public static class ServiceCollectionApplicationExtensions
{
    public static ICrmApplicationWithExternalServiceProvider AddApplication<TStartupModule>(
        this IServiceCollection services,
        Action<CrmApplicationCreationOptions>? option = null)
        where TStartupModule : IModule
    {
        return CrmApplicationFactory.Create<TStartupModule>(services, option);
    }

    public static ICrmApplicationWithExternalServiceProvider AddApplication(
        this IServiceCollection services,
        Type startupModuleType,
        Action<CrmApplicationCreationOptions> optionsAction = null)
    {
        return CrmApplicationFactory.Create(startupModuleType, services, optionsAction);
    }

    public async static Task<ICrmApplicationWithExternalServiceProvider> AddApplicationAsync<TStartupModule>(
        this IServiceCollection services,
        Action<CrmApplicationCreationOptions> optionsAction = null)
        where TStartupModule : IModule
    {
        return await CrmApplicationFactory.CreateAsync<TStartupModule>(services, optionsAction);
    }

    public async static Task<ICrmApplicationWithExternalServiceProvider> AddApplicationAsync(
        this IServiceCollection services,
        Type startupModuleType,
        Action<CrmApplicationCreationOptions> optionsAction = null)
    {
        return await CrmApplicationFactory.CreateAsync(startupModuleType, services, optionsAction);
    }

    //public static string GetApplicationName(this IServiceCollection services)
    //{
    //    return services.GetSingletonInstance<IApplicationInfoAccessor>().ApplicationName;
    //}


    //public static string GetApplicationInstanceId(this IServiceCollection services)
    //{
    //    return services.GetSingletonInstance<IApplicationInfoAccessor>().InstanceId;
    //}


    //public static ICrmHostEnvironment GetCrmHostEnvironment(this IServiceCollection services)
    //{
    //    return services.GetSingletonInstance<ICrmHostEnvironment>();
    //}
}

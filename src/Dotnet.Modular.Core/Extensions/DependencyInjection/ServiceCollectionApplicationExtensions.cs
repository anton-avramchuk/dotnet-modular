using Microsoft.Extensions.DependencyInjection;
using System;

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

}

using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dotnet.Modular.Core;

public static class CrmApplicationFactory
{
    

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
        
        return new CrmApplicationWithExternalServiceProvider(startupModuleType, services, optionsAction);
    }

   
}

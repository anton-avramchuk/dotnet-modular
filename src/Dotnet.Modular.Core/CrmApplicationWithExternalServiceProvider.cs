using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dotnet.Modular.Core;

internal class CrmApplicationWithExternalServiceProvider : CrmApplicationBase, ICrmApplicationWithExternalServiceProvider
{
    public CrmApplicationWithExternalServiceProvider(
         Type startupModuleType,
         IServiceCollection services,
        Action<CrmApplicationCreationOptions>? optionsAction
        ) : base(
            startupModuleType,
            services,
            optionsAction)
    {
        services.AddSingleton<ICrmApplicationWithExternalServiceProvider>(this);
    }

    void ICrmApplicationWithExternalServiceProvider.SetServiceProvider(IServiceProvider serviceProvider)
    {

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (ServiceProvider != null)
        {
            if (ServiceProvider != serviceProvider)
            {
                throw new Exception("Service provider was already set before to another service provider instance.");
            }

            return;
        }

        SetServiceProvider(serviceProvider);
    }


    public void Initialize(IServiceProvider serviceProvider)
    {
        SetServiceProvider(serviceProvider);

        InitializeModules();
    }

    public override void Dispose()
    {
        base.Dispose();

        if (ServiceProvider is IDisposable disposableServiceProvider)
        {
            disposableServiceProvider.Dispose();
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Dotnet.Modular.Core
{
    public abstract class ModuleBase : IModule, IPreConfigureServices, IPostConfigureServices,
        IOnPreApplicationInitialization,
        IOnApplicationInitialization,
        IOnPostApplicationInitialization,
        IOnApplicationShutdown
    {
        private ServiceConfigurationContext? _serviceConfigurationContext;



        public virtual void ConfigureServices(ServiceConfigurationContext context)
        {

        }

        public virtual void PreConfigureServices(ServiceConfigurationContext context)
        {

        }

        public virtual void PostConfigureServices(ServiceConfigurationContext context)
        {

        }


        protected void Configure<TOptions>(Action<TOptions> configureOptions)
        where TOptions : class
        {
            ServiceConfigurationContext.Services.Configure(configureOptions);
        }

        protected void Configure<TOptions>(string name, Action<TOptions> configureOptions)
            where TOptions : class
        {
            ServiceConfigurationContext.Services.Configure(name, configureOptions);
        }

        public virtual Task OnPreApplicationInitializationAsync(ApplicationInitializationContext context)
        {
            OnPreApplicationInitialization(context);
            return Task.CompletedTask;
        }

        public virtual void OnPreApplicationInitialization(ApplicationInitializationContext context)
        {

        }

        public virtual Task OnApplicationInitializationAsync(ApplicationInitializationContext context)
        {
            OnApplicationInitialization(context);
            return Task.CompletedTask;
        }

        public virtual void OnApplicationInitialization(ApplicationInitializationContext context)
        {

        }

        public virtual Task OnPostApplicationInitializationAsync(ApplicationInitializationContext context)
        {
            OnPostApplicationInitialization(context);
            return Task.CompletedTask;
        }

        public virtual void OnPostApplicationInitialization(ApplicationInitializationContext context)
        {

        }

        public virtual Task OnApplicationShutdownAsync(ApplicationShutdownContext context)
        {
            OnApplicationShutdown(context);
            return Task.CompletedTask;
        }

        public virtual void OnApplicationShutdown(ApplicationShutdownContext context)
        {

        }

        
        protected internal ServiceConfigurationContext ServiceConfigurationContext
        {
            get
            {
                if (_serviceConfigurationContext == null)
                {
                    throw new Exception($"{nameof(ServiceConfigurationContext)} is only available in the {nameof(ConfigureServices)}, {nameof(PreConfigureServices)} and {nameof(PostConfigureServices)} methods.");
                }

                return _serviceConfigurationContext;
            }
            internal set => _serviceConfigurationContext = value;
        }
    }
}

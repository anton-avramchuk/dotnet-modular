using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dotnet.Modular.Core
{
    public abstract class ModuleBase : IModule, IPreConfigureServices, IPostConfigureServices
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

        //protected void Configure<TOptions>(IConfiguration configuration)
        //    where TOptions : class
        //{
        //    ServiceConfigurationContext.Services.Configure<TOptions>(configuration);
        //}

        //protected void Configure<TOptions>(IConfiguration configuration, Action<BinderOptions> configureBinder)
        //    where TOptions : class
        //{
        //    ServiceConfigurationContext.Services.Configure<TOptions>(configuration, configureBinder);
        //}

        //protected void Configure<TOptions>(string name, IConfiguration configuration)
        //    where TOptions : class
        //{
        //    ServiceConfigurationContext.Services.Configure<TOptions>(name, configuration);
        //}

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

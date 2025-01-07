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

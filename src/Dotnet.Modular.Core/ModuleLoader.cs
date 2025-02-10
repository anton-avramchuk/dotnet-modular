using Dotnet.Modular.Core.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Dotnet.Modular.Core
{
    public class ModuleLoader : IModuleLoader
    {
        public IModuleDescriptor[] LoadModules(
            IServiceCollection services,
            Type startupModuleType)
        {

            return ModuleInitializer.Modules.Select(x => CreateModuleDescriptor(services, x)).ToArray();
        }


        protected virtual CrmModuleDescriptor CreateModuleDescriptor(IServiceCollection services, Type moduleType)
        {
            return new CrmModuleDescriptor(moduleType, CreateAndRegisterModule(services, moduleType));
        }

        protected virtual IModule CreateAndRegisterModule(IServiceCollection services, Type moduleType)
        {
            var module = (IModule)Activator.CreateInstance(moduleType)!;
            services.AddSingleton(moduleType, module);
            return module;
        }

    }

}

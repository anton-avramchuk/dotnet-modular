using Dotnet.Modular.Core.Abstractions;
using Dotnet.Modular.Core.States;

namespace Dotnet.Modular.Core
{
    public class CrmModuleLifecycleOptions
    {
        public ITypeList<IModuleLifecycleContributor> Contributors { get; }

        public CrmModuleLifecycleOptions()
        {
            Contributors = new TypeList<IModuleLifecycleContributor>();
        }
    }
}

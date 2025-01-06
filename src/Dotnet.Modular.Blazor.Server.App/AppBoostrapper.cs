using Dotnet.Modular.Core;
using IModule = Dotnet.Modular.Core.IModule;

namespace Dotnet.Modular.Blazor.Server.App
{

    [Bootstraper]
    public partial class AppBoostrapper : IModule
    {
        public AppBoostrapper()
        {
        }

        public void ConfigureServices(ServiceConfigurationContext context)
        {
            throw new NotImplementedException();
        }
    }
}

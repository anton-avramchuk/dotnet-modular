using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.Blazor.Components.Bootstrap;

namespace Dotnet.Modular.Blazor.Server.App
{

    [Bootstraper]
    [DependsOn(typeof(BlazorComponentsBootstrapModule))]
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

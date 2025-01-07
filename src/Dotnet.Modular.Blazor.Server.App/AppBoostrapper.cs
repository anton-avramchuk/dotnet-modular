using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.Blazor.Components.Bootstrap;

namespace Dotnet.Modular.Blazor.Server.App
{

    [Bootstraper]
    [DependsOn(typeof(BlazorComponentsBootstrapModule))]
    public partial class AppBoostrapper : ModuleBase
    {
        public AppBoostrapper()
        {
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            RegisterServices(context.Services);
        }
    }
}

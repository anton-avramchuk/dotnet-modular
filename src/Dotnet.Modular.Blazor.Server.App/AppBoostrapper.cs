using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.Blazor.Layout.Material;

namespace Dotnet.Modular.Blazor.Server.App
{

    [Bootstraper]
    [DependsOn(typeof(BlazorLayoutMaterialModule))]
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

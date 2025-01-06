using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.Blazor.Components.Core;

namespace Dotnet.Modular.Modules.Blazor.Components.Bootstrap
{
    [DependsOn(typeof(BlazorComponentsCoreModule))]
    public partial class BlazorComponentsBootstrapModule : ModuleBase
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            RegisterServices(context.Services);
        }
    }
}

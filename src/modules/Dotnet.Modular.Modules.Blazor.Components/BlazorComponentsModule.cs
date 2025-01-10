using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.Blazor.Components.Core;

namespace Dotnet.Modular.Modules.Blazor.Components;

[DependsOn(typeof(BlazorComponentsCoreModule))]
public partial class BlazorComponentsModule : ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        base.ConfigureServices(context);
        RegisterServices(context.Services);
    }
}

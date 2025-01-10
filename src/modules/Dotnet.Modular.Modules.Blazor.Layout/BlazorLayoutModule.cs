using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.Blazor.Layout.Core;

namespace Dotnet.Modular.Modules.Blazor.Layout;

[DependsOn(typeof(BlazorLayoutCoreModule))]
public partial class BlazorLayoutModule : ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        base.ConfigureServices(context);
        RegisterServices(context.Services);
    }
}

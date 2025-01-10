using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.Blazor.Layout.Core;

namespace Dotnet.Modular.Modules.Blazor.Layout.Bootstrap;

[DependsOn(typeof(BlazorLayoutCoreModule))]
public partial class BlazorBootstrapLayoutModule: ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        base.ConfigureServices(context);
        RegisterServices(context.Services);
    }
}

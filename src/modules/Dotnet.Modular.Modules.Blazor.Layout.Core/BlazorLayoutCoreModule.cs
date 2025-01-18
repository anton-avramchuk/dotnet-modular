using Dotnet.Modular.Core;

namespace Dotnet.Modular.Modules.Blazor.Layout.Core;

public partial class BlazorLayoutCoreModule: ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        base.ConfigureServices(context);
        RegisterServices(context.Services);
    }
}

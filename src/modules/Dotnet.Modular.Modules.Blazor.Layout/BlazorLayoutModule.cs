using Dotnet.Modular.Core;

namespace Dotnet.Modular.Modules.Blazor.Layout;

public partial class BlazorLayoutModule : ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        base.ConfigureServices(context);
        RegisterServices(context.Services);
    }
}

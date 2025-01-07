using Dotnet.Modular.Core;

namespace Dotnet.Modular.Modules.Blazor.Components.Core;

public partial class BlazorComponentsCoreModule : ModuleBase
{

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
    }
}

using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.Navigation;
using Dotnet.Modular.Modules.UI;

namespace Dotnet.Modular.Modules.Blazor.Layout;

[DependsOn(typeof(UIModule),typeof(NavigationModule))]
public partial class BlazorLayoutModule : ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        base.ConfigureServices(context);
        RegisterServices(context.Services);
    }
}

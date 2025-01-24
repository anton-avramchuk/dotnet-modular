using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.UI;

namespace Dotnet.Modular.Modules.Navigation;

[DependsOn(typeof(UIModule))]
public partial class NavigationModule : ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
    }
}

using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.Blazor.Material;
using Dotnet.Modular.Modules.Navigation;
using Dotnet.Modular.Modules.UI;

namespace Dotnet.Modular.Modules.Blazor.Layout.Material;

[DependsOn(typeof(BlazorMaterialModule), typeof(UIModule), typeof(BlazorLayoutModule), typeof(NavigationModule))]
public partial class BlazorLayoutMaterialModule : ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
    }
}

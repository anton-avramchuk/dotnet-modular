using Dotnet.Modular.Blazor.Server.App.Services;
using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.Blazor.Layout.Material;
using Dotnet.Modular.Modules.Navigation;
using Dotnet.Modular.Modules.UI;

namespace Dotnet.Modular.Blazor.Server.App
{

    [Bootstraper]
    [DependsOn(typeof(BlazorLayoutMaterialModule))]
    [DependsOn(typeof(UIModule))]
    [DependsOn(typeof(NavigationModule))]
    public partial class AppBoostrapper : ModuleBase
    {
        public AppBoostrapper()
        {
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            RegisterServices(context.Services);
            Configure<NavigationOptions>(options =>
            {
                options.MenuProviders.Add(new MainMenuProvider());
            });
        }
    }
}

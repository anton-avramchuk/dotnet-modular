using Dotnet.Modular.AspNetCore;
using Dotnet.Modular.Auth;
using Dotnet.Modular.Auth.Extensions;
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
    [DependsOn(typeof(AspNetCoreModule))]
    [DependsOn(typeof(AuthModule))]
    public partial class AppBoostrapper : ModuleBase
    {
        public AppBoostrapper()
        {
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            RegisterServices(context.Services);
            context.Services.AddCookieAuth();
            Configure<NavigationOptions>(options =>
            {
                options.MenuProviders.Add(new MainMenuProvider());
            });
        }
    }
}

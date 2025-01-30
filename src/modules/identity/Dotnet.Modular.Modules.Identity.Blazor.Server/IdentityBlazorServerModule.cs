using Dotnet.Modular.Core;

namespace Dotnet.Modular.Modules.Identity.Blazor.Server;

[DependsOn(typeof(IdentityBlazorModule))]
public partial class IdentityBlazorServerModule : ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
    }
}

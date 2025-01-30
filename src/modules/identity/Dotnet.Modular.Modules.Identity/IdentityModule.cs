using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.Core;

namespace Dotnet.Modular.Modules.Identity;

[DependsOn(typeof(CoreModule))]
public partial class IdentityModule : ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
    }
}

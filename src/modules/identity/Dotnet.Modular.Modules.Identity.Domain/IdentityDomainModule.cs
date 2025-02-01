using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.Domain;

namespace Dotnet.Modular.Modules.Identity.Domain;

[DependsOn(typeof(DomainModule))]
public partial class IdentityDomainModule : ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
    }
}

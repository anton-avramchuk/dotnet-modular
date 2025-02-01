using Dotnet.Modular.Core;

namespace Dotnet.Modular.Modules.Identity.Domain;

public partial class IdentityDomainConstantsModule : ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
    }
}

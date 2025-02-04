using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.Core;
using Dotnet.Modular.Modules.EntityFramework;
using Dotnet.Modular.Modules.Identity.Domain;
using Dotnet.Modular.Security;

namespace Dotnet.Modular.Modules.Identity;

[DependsOn(typeof(CoreModule), typeof(SecurityModule), typeof(IdentityDomainModule), typeof(EntityFrameworkModule), typeof(IdentityDomainConstantsModule))]
public partial class IdentityModule : ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
    }
}

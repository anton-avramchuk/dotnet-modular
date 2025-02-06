using Dotnet.Modular.Auth.Core;
using Dotnet.Modular.Core;
using Dotnet.Modular.Security;

namespace Dotnet.Modular.Auth;

[DependsOn(typeof(AuthCoreModule), typeof(SecurityModule))]
public partial class AuthModule : ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
    }
}

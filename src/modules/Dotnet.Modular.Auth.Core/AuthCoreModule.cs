using Dotnet.Modular.Core;

namespace Dotnet.Modular.Auth.Core;

public partial class AuthCoreModule : ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
    }
}

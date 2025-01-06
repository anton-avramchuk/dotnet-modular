using Dotnet.Modular.Core;

namespace Dotnet.Modular.Modules.Core;

public partial class CoreModule : ModuleBase
{
    

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
    }
}

using Dotnet.Modular.Core;

namespace Dotnet.Modular.Modules.Data;

public partial class DataModule : ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
    }
}

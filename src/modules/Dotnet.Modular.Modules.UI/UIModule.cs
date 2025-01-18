using Dotnet.Modular.Core;

namespace Dotnet.Modular.Modules.UI;

public partial class UIModule: ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
    }
}

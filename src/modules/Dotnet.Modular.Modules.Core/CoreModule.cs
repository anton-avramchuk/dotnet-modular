using Dotnet.Modular.Core;

namespace Dotnet.Modular.Modules.Core;

public partial class CoreModule : IModule
{
    public string Name => nameof(CoreModule);

    public void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
    }
}

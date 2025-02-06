using Dotnet.Modular.Core;

namespace Dotnet.Modular.Blazor.Server;

[DependsOn(typeof(BlazorModule))]
public partial class BlazorServerModule: ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
    }
}

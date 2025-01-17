using Dotnet.Modular.Core;

namespace Dotnet.Modular.Modules.Blazor.Layout.Bootstrap;

public partial class BlazorBootstrapLayoutModule: ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        base.ConfigureServices(context);
        RegisterServices(context.Services);
    }
}

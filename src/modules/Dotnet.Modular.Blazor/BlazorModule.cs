using Dotnet.Modular.Auth;
using Dotnet.Modular.Core;

namespace Dotnet.Modular.Blazor;

[DependsOn(typeof(AuthModule))]
public partial class BlazorModule: ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
    }
}

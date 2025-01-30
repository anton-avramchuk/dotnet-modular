using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.Blazor.Components;
using Dotnet.Modular.Modules.Identity.Domain;

namespace Dotnet.Modular.Modules.Identity.Blazor;

[DependsOn(typeof(BlazorComponentsModule))]
[DependsOn(typeof(IdentityDomainModule))]
public partial class IdentityBlazorModule : ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
    }
}

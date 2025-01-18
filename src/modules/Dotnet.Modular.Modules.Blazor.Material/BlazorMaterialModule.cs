using Dotnet.Modular.Core;
using MudBlazor.Services;

namespace Dotnet.Modular.Modules.Blazor.Material;


public partial class BlazorMaterialModule : ModuleBase
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        RegisterServices(context.Services);
        context.Services.AddMudServices();
    }
}

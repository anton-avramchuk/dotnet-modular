using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.Blazor.Components.Core;
using Dotnet.Modular.Modules.Blazor.Material;

namespace Dotnet.Modular.Modules.Blazor.Components.Material;

[DependsOn(typeof(BlazorComponentsCoreModule), typeof(BlazorMaterialModule))]
public partial class BlazorComponentsMaterialModule : ModuleBase
{

}

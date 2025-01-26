using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.Blazor.Material;
using Dotnet.Modular.Modules.UI;

namespace Dotnet.Modular.Modules.Blazor.Layout.Material;

[DependsOn(typeof(BlazorMaterialModule), typeof(UIModule), typeof(BlazorLayoutModule))]
public partial class BlazorLayoutMaterialModule : ModuleBase
{

}

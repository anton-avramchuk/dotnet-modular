using Dotnet.Modular.Modules.Blazor.Layout.Core.Components.Abstractions;
using Microsoft.AspNetCore.Components;

namespace Dotnet.Modular.Modules.Blazor.Layout.Bootstrap.Components
{
    public partial class Sidebar : ComponentBase, ISidebar
    {
        public bool Visible { get; set; }
    }
}

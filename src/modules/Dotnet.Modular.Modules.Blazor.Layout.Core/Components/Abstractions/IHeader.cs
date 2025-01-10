using Microsoft.AspNetCore.Components;

namespace Dotnet.Modular.Modules.Blazor.Layout.Core.Components.Abstractions
{
    public interface IHeader
    {
        EventCallback ToggleSidebar { get; set; }
    }
}

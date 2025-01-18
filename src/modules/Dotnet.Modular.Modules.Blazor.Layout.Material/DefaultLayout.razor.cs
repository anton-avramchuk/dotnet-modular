using Dotnet.Modular.Modules.UI.Services.Abstractions;
using Microsoft.AspNetCore.Components;

namespace Dotnet.Modular.Modules.Blazor.Layout.Material
{
    public partial class DefaultLayout : LayoutComponentBase
    {
        [Inject]
        private IBrandingProvider BrandingProvider { get; set; }


        private bool _drawerOpen = true;

        private void ToggleDrawer()
        {
            _drawerOpen = !_drawerOpen;
        }


        public string AppName => BrandingProvider.AppName;
    }
}

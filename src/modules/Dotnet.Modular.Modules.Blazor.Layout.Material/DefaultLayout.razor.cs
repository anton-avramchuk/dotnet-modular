using Microsoft.AspNetCore.Components;

namespace Dotnet.Modular.Modules.Blazor.Layout.Material
{
    public partial class DefaultLayout : LayoutComponentBase
    {
        private bool _drawerOpen = true;

        private void ToggleDrawer()
        {
            _drawerOpen = !_drawerOpen;
        }


        public string AppName => "Modular App";
    }
}

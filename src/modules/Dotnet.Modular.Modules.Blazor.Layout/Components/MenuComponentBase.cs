using Dotnet.Modular.Modules.Navigation;
using Microsoft.AspNetCore.Components;

namespace Dotnet.Modular.Modules.Blazor.Layout.Components
{
    public abstract class MenuComponentBase : ComponentBase
    {
        
        public IApplicationMenu Menu { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Menu = await GetMenu();
        }


        protected abstract Task<IApplicationMenu> GetMenu();
    }

    public abstract class MenuManagerMenuComponentBase : MenuComponentBase
    {
        [Inject]
        protected IMenuManager MenuManager { get; set; }

    }


    public abstract class MenuWithNameComponentBase : MenuManagerMenuComponentBase
    {
        [Inject]
        protected IMenuManager MenuManager { get; set; }

        protected abstract string MenuName { get;}

        protected override async Task<IApplicationMenu> GetMenu()
        {
            return await MenuManager.GetAsync(MenuName);
        }
    }


    public abstract class MainMenuComponentBase : MenuManagerMenuComponentBase
    {
        protected override async Task<IApplicationMenu> GetMenu()
        {
            return await MenuManager.GetMainMenuAsync();
        }
    }
}

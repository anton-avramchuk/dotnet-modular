using Dotnet.Modular.Modules.Navigation;

namespace Dotnet.Modular.Blazor.Server.App.Services
{
    public class MainMenuProvider : IMenuProvider
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                MainMenu.Dashboard,
                "Dashboard",
                "/"
            ));

            context.Menu.Items.Insert(
            1,
            new ApplicationMenuItem(
                MainMenu.Counter,
                "Counter",
                "/counter"
            ));

            return Task.CompletedTask;
        }
    }
}

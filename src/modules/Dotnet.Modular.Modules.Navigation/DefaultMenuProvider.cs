using Dotnet.Modular.Modules.UI;

namespace Dotnet.Modular.Modules.Navigation;

public class DefaultMenuProvider : IMenuProvider
{
    public virtual Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        Configure(context);
        return Task.CompletedTask;
    }

    protected virtual void Configure(MenuConfigurationContext context)
    {


        if (context.Menu.Name == StandardMenus.Main)
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(
                    DefaultMenuNames.Application.Main.Administration,
                    "Administration",
                    url: "/admin",
                    icon: FontIcons.Admin
                )
            );
        }
    }
}

namespace Dotnet.Modular.Modules.Navigation;

public static class ApplicationMenuExtensions
{
    public const string CustomDataComponentKey = "ApplicationMenu.CustomComponent";


    public static IApplicationMenuItem GetAdministration(
        this ApplicationMenu applicationMenu)
    {
        return applicationMenu.GetMenuItem(
            DefaultMenuNames.Application.Main.Administration
        );
    }


    public static IApplicationMenuItem GetMenuItem(
        this IHasMenuItems menuWithItems,
        string menuItemName)
    {
        var menuItem = menuWithItems.GetMenuItemOrNull(menuItemName);
        if (menuItem == null)
        {
            throw new Exception($"Could not find a menu item with given name: {menuItemName}");
        }

        return menuItem;
    }

    public static IApplicationMenuItem? GetMenuItemOrNull(
        this IHasMenuItems menuWithItems,
        string menuItemName)
    {
        return menuWithItems.Items.FirstOrDefault(mi => mi.Name == menuItemName);
    }

}


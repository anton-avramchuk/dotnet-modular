namespace Dotnet.Modular.Modules.Navigation;

public interface IApplicationMenu
{
    string Name { get; }

    string? DisplayName { get; }
    //remove list
    ApplicationMenuItemList Items { get; }

    IApplicationMenu AddItem(IApplicationMenuItem menuItem);
}

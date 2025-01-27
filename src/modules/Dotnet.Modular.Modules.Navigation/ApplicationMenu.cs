namespace Dotnet.Modular.Modules.Navigation;

public class ApplicationMenu : IApplicationMenu, IHasMenuItems
{
    public string Name { get; }

    public ApplicationMenuItemList Items { get; }

    public string? DisplayName { get; }

    

    public ApplicationMenu(
        string name,
        string? displayName = null)
    {
        Name = name;
        DisplayName = displayName ?? Name;
        Items = new ApplicationMenuItemList();
    }

    /// <summary>
    /// Adds a <see cref="IApplicationMenuItem"/> to <see cref="Items"/>.
    /// </summary>
    /// <param name="menuItem"><see cref="ApplicationMenuItem"/> to be added</param>
    /// <returns>This <see cref="ApplicationMenu"/> object</returns>
    public IApplicationMenu AddItem(IApplicationMenuItem menuItem)
    {
        Items.Add(menuItem);
        return this;
    }
}

namespace Dotnet.Modular.Modules.Navigation;

public class ApplicationMenu : IApplicationMenu
{
    public string Name { get; }

    public IList<IApplicationMenuItem> Items { get; }

    public string? DisplayName { get; }

    

    public ApplicationMenu(
        string name,
        string? displayName = null)
    {
        Name = name;
        DisplayName = displayName ?? Name;
        Items = new ApplicationMenuItemList();
    }
}

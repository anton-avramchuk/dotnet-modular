using System.Text.RegularExpressions;

namespace Dotnet.Modular.Modules.Navigation;

public interface IApplicationMenu
{
    string Name { get; }

    string? DisplayName { get; }

    IReadOnlyCollection<IApplicationMenuItem> Items { get; }
}

public class ApplicationMenu : IApplicationMenu
{
    public string Name { get; }

    public IReadOnlyCollection<IApplicationMenuItem> Items { get; }

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

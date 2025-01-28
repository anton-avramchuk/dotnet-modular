namespace Dotnet.Modular.Modules.Navigation;

public class NavigationOptions
{

    public List<IMenuProvider> MenuProviders { get; }

    /// <summary>
    /// Includes the <see cref="StandardMenus.Main"/> by default.
    /// </summary>
    public List<string> MainMenuNames { get; }

    public NavigationOptions()
    {
        MenuProviders = new List<IMenuProvider>();

        MainMenuNames = new List<string>
            {
                StandardMenus.Main
            };
    }
}

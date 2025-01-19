namespace Dotnet.Modular.Modules.Navigation;

public interface IMenuManager
{
    Task<IApplicationMenu> GetAsync(string name);

    Task<IApplicationMenu> GetMainMenuAsync();
}

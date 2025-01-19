using Dotnet.Modular.Core;

namespace Dotnet.Modular.Modules.Navigation;

[Export(ExportType.Trancient, typeof(IMenuManager))]
public class MenuManager : IMenuManager
{
    public Task<IApplicationMenu> GetAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<IApplicationMenu> GetMainMenuAsync()
    {
        throw new NotImplementedException();
    }
}

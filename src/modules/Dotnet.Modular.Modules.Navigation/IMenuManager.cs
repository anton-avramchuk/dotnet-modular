using Dotnet.Modular.Core;

namespace Dotnet.Modular.Modules.Navigation;

public interface IMenuManager
{

}

[Export(ExportType.Trancient, typeof(IMenuManager))]
public class MenuManager : IMenuManager
{

}

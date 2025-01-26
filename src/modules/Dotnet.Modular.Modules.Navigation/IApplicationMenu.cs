using System.Text.RegularExpressions;

namespace Dotnet.Modular.Modules.Navigation;

public interface IApplicationMenu
{
    string Name { get; }

    string? DisplayName { get; }
    //remove list
    IList<IApplicationMenuItem> Items { get; }
}

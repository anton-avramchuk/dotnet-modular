namespace Dotnet.Modular.Modules.Navigation;

public interface IApplicationMenu
{
    string Name { get; }

    IEnumerable<IApplicationMenuItem> Items { get; }
}

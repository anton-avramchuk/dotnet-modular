namespace Dotnet.Modular.Modules.Navigation;

public interface IHasMenuItems
{
    /// <summary>
    /// Menu items.
    /// </summary>
    ApplicationMenuItemList Items { get; }
}


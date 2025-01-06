namespace Dotnet.Modular.Modules.Navigation;

public interface IApplicationMenuItem
{
    string? CssClass { get; set; }
    Dictionary<string, object> CustomData { get; }
    string DisplayName { get; set; }
    string? ElementId { get; set; }
    string? GroupName { get; set; }
    string? Icon { get; set; }
    bool IsDisabled { get; set; }
    bool IsLeaf { get; }
    
    string Name { get; }
    int Order { get; set; }
    string? RequiredPermissionName { get; set; }
    string? Target { get; set; }
    string? Url { get; set; }

    IApplicationMenuItem AddItem(IApplicationMenuItem menuItem);
}

using Dotnet.Modular.Modules.Navigation;
using Dotnet.Modular.Modules.UI;
using Microsoft.AspNetCore.Components;

namespace Dotnet.Modular.Modules.Blazor.Layout.Components;

public abstract class MenuItemComponentBase : ComponentBase
{
    [Inject]
    protected IIconTransformer IconTransformer { get; set; } = default!;

    private string? _icon;

    [Parameter]
    public string? CssClass { get; set; }

    [Parameter]
    public Dictionary<string, object> CustomData { get; set; } = new();

    [Parameter]
    public string DisplayName { get; set; } = default!;

    [Parameter]
    public string? ElementId { get; set; }

    [Parameter]
    public string? GroupName { get; set; }

    [Parameter]
    public string? Icon { get; set; }

    [Parameter]
    public bool IsDisabled { get; set; }

    [Parameter]
    public bool IsLeaf { get; set; }

    [Parameter]
    public string Name { get; set; } = default!;

    [Parameter]
    public int Order { get; set; }

    [Parameter]
    public string? RequiredPermissionName { get; set; }

    [Parameter]
    public string? Target { get; set; }

    [Parameter]
    public string? Url { get; set; }

    [Parameter]
    public IApplicationMenuItem MenuItem { get; set; } = default!;

    public string? TransformedIcon => _icon;

    public bool HasChildren
    {
        get
        {
            return !MenuItem.IsLeaf;
        }
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        if (MenuItem != null)
        {
            CssClass = MenuItem.CssClass;
            CustomData = MenuItem.CustomData;
            DisplayName = MenuItem.DisplayName;
            ElementId = MenuItem.ElementId;
            GroupName = MenuItem.GroupName;
            Icon = MenuItem.Icon; 
            IsDisabled = MenuItem.IsDisabled;
            IsLeaf = MenuItem.IsLeaf;
            Name = MenuItem.Name;
            Order = MenuItem.Order;
            RequiredPermissionName = MenuItem.RequiredPermissionName;
            Target = MenuItem.Target;
            Url = MenuItem.Url;
        }
        if (Icon != null)
        {
            _icon = IconTransformer.Transform(Icon);
        }
    }
}

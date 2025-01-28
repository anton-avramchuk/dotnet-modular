using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.UI;

namespace Dotnet.Modular.Modules.Blazor.Layout.Material.Services;

/// <summary>
/// Transforms framework-agnostic icon names to Material Design Icons
/// </summary>
[Export(ExportType.Single, typeof(IIconTransformer))]
public class MaterialIconTransformer : IIconTransformer
{
    private static readonly Dictionary<string, string> IconMappings = new()
    {
        // Navigation and Menu
        { FontIcons.Menu, MudBlazor.Icons.Material.Filled.Menu },
        { FontIcons.Dashboard, MudBlazor.Icons.Material.Filled.Dashboard },
        { FontIcons.Home, MudBlazor.Icons.Material.Filled.Home },
        { FontIcons.Back, MudBlazor.Icons.Material.Filled.ArrowBack },
        { FontIcons.Forward, MudBlazor.Icons.Material.Filled.ArrowForward },
        { FontIcons.Close, MudBlazor.Icons.Material.Filled.Close },

        // Common Actions
        { FontIcons.Add, MudBlazor.Icons.Material.Filled.Add },
        { FontIcons.Edit, MudBlazor.Icons.Material.Filled.Edit },
        { FontIcons.Delete, MudBlazor.Icons.Material.Filled.Delete },
        { FontIcons.Save, MudBlazor.Icons.Material.Filled.Save },
        { FontIcons.Cancel, MudBlazor.Icons.Material.Filled.Cancel },

        // Status and Feedback
        { FontIcons.Success, MudBlazor.Icons.Material.Filled.CheckCircle },
        { FontIcons.Warning, MudBlazor.Icons.Material.Filled.Warning },
        { FontIcons.Error, MudBlazor.Icons.Material.Filled.Error },
        { FontIcons.Info, MudBlazor.Icons.Material.Filled.Info },
        { FontIcons.Help, MudBlazor.Icons.Material.Filled.Help },

        // Content
        { FontIcons.Search, MudBlazor.Icons.Material.Filled.Search },
        { FontIcons.Filter, MudBlazor.Icons.Material.Filled.FilterList },
        { FontIcons.Sort, MudBlazor.Icons.Material.Filled.Sort },
        { FontIcons.Settings, MudBlazor.Icons.Material.Filled.Settings },
        { FontIcons.Download, MudBlazor.Icons.Material.Filled.Download },
        { FontIcons.Upload, MudBlazor.Icons.Material.Filled.Upload },
        { FontIcons.Print, MudBlazor.Icons.Material.Filled.Print },
        { FontIcons.Share, MudBlazor.Icons.Material.Filled.Share },

        // Navigation Controls
        { FontIcons.Previous, MudBlazor.Icons.Material.Filled.ChevronLeft },
        { FontIcons.Next, MudBlazor.Icons.Material.Filled.ChevronRight },
        { FontIcons.Up, MudBlazor.Icons.Material.Filled.KeyboardArrowUp },
        { FontIcons.Down, MudBlazor.Icons.Material.Filled.KeyboardArrowDown },
        { FontIcons.Expand, MudBlazor.Icons.Material.Filled.ExpandMore },
        { FontIcons.Collapse, MudBlazor.Icons.Material.Filled.ExpandLess }
    };

    /// <summary>
    /// Transforms a framework-agnostic icon name to a Material Design icon name
    /// </summary>
    /// <param name="iconName">Framework-agnostic icon name from FontIcons class</param>
    /// <returns>Material Design icon name or the original name if no mapping exists</returns>
    public string Transform(string iconName)
    {
        if (iconName == null)
            return string.Empty;

        return IconMappings.TryGetValue(iconName, out var materialIcon)
            ? materialIcon
            : iconName;
    }
}

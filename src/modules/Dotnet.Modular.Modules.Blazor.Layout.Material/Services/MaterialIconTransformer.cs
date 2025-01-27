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
        { FontIcons.Menu, "menu" },
        { FontIcons.Dashboard, "dashboard" },
        { FontIcons.Home, "home" },
        { FontIcons.Back, "arrow_back" },
        { FontIcons.Forward, "arrow_forward" },
        { FontIcons.Close, "close" },

        // Common Actions
        { FontIcons.Add, "add" },
        { FontIcons.Edit, "edit" },
        { FontIcons.Delete, "delete" },
        { FontIcons.Save, "save" },
        { FontIcons.Cancel, "cancel" },

        // Status and Feedback
        { FontIcons.Success, "check_circle" },
        { FontIcons.Warning, "warning" },
        { FontIcons.Error, "error" },
        { FontIcons.Info, "info" },
        { FontIcons.Help, "help" },

        // Content
        { FontIcons.Search, "search" },
        { FontIcons.Filter, "filter_list" },
        { FontIcons.Sort, "sort" },
        { FontIcons.Settings, "settings" },
        { FontIcons.Download, "download" },
        { FontIcons.Upload, "upload" },
        { FontIcons.Print, "print" },
        { FontIcons.Share, "share" },

        // Navigation Controls
        { FontIcons.Previous, "chevron_left" },
        { FontIcons.Next, "chevron_right" },
        { FontIcons.Up, "keyboard_arrow_up" },
        { FontIcons.Down, "keyboard_arrow_down" },
        { FontIcons.Expand, "expand_more" },
        { FontIcons.Collapse, "expand_less" }
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

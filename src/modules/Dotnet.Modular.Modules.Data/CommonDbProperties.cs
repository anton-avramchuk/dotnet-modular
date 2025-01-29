namespace Dotnet.Modular.Modules.Data;

public static class CommonDbProperties
{
    
    public static string DbTablePrefix { get; set; } = "Crm";

    /// <summary>
    /// Default value: null.
    /// </summary>
    public static string? DbSchema { get; set; } = null;
}

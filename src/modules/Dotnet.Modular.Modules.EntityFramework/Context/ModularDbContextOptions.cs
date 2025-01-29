namespace Dotnet.Modular.Modules.EntityFramework.Context;

public class ModularDbContextOptions
{
    public string ConnectionString { get; set; } = null!;
    public string? Schema { get; set; }
    public string? TablePrefix { get; set; }
    public int? CommandTimeout { get; set; }
    public bool EnableDetailedErrors { get; set; }
    public bool EnableSensitiveDataLogging { get; set; }
}

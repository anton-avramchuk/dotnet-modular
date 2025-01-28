namespace Dotnet.Modular.Modules.Data.Abstractions;

public interface IConnectionStringResolver
{



    Task<string> ResolveAsync(string? connectionStringName = null);
}

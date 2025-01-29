namespace Dotnet.Modular.Modules.Data.Abstractions;

public interface IConnectionStringChecker
{
    Task<ConnectionStringCheckResult> CheckAsync(string connectionString);
}

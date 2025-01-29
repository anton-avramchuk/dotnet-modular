using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.Data.Abstractions;

namespace Dotnet.Modular.Modules.Data;

[Export(ExportType.Trancient, typeof(IConnectionStringChecker))]
public class DefaultConnectionStringChecker : IConnectionStringChecker
{
    public Task<ConnectionStringCheckResult> CheckAsync(string connectionString)
    {
        return Task.FromResult(new ConnectionStringCheckResult
        {
            Connected = false,
            DatabaseExists = false
        });
    }
}

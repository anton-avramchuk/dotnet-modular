using Dotnet.Modular.Core;
using Dotnet.Modular.Core.Extensions.Common;
using Dotnet.Modular.Modules.Data.Abstractions;
using Microsoft.Extensions.Options;

namespace Dotnet.Modular.Modules.Data;

[Export(ExportType.Trancient, typeof(IConnectionStringResolver))]
public class DefaultConnectionStringResolver : IConnectionStringResolver
{
    protected DbConnectionOptions Options { get; }

    public DefaultConnectionStringResolver(
        IOptionsMonitor<DbConnectionOptions> options)
    {
        Options = options.CurrentValue;
    }

    [Obsolete("Use ResolveAsync method.")]
    public virtual string Resolve(string? connectionStringName = null)
    {
        return ResolveInternal(connectionStringName)!;
    }

    public virtual Task<string> ResolveAsync(string? connectionStringName = null)
    {
        return Task.FromResult(ResolveInternal(connectionStringName))!;
    }

    private string? ResolveInternal(string? connectionStringName)
    {
        if (connectionStringName == null)
        {
            return Options.ConnectionStrings.Default;
        }

        var connectionString = Options.GetConnectionStringOrNull(connectionStringName);

        if (!connectionString.IsNullOrEmpty())
        {
            return connectionString;
        }

        return null;
    }
}

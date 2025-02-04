using Dotnet.Modular.Core;
using System.Data.Common;

namespace Dotnet.Modular.Modules.EntityFramework;

public class DataContextCreationContext
{
    public static DataContextCreationContext Current => _current.Value;
    private static readonly AsyncLocal<DataContextCreationContext> _current = new AsyncLocal<DataContextCreationContext>();

    public string ConnectionStringName { get; }

    public string ConnectionString { get; }

    public DbConnection ExistingConnection { get; internal set; }

    public DataContextCreationContext(string connectionStringName, string connectionString)
    {
        ConnectionStringName = connectionStringName;
        ConnectionString = connectionString;
    }

    public static IDisposable Use(DataContextCreationContext context)
    {
        var previousValue = Current;
        _current.Value = context;
        return new DisposeAction(() => _current.Value = previousValue);
    }
}
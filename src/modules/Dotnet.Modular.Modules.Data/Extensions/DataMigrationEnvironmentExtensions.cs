using Microsoft.Extensions.DependencyInjection;
using Dotnet.Modular.Core.Extensions.DependencyInjection;
using Dotnet.Modular.Core;
namespace Dotnet.Modular.Modules.Data.Extensions;

public static class DataMigrationEnvironmentExtensions
{
   

    public static void AddDataMigrationEnvironment(this IServiceCollection services, DataMigrationEnvironment? environment = null)
    {
        services.AddObjectAccessor(environment ?? new DataMigrationEnvironment());
    }

    public static DataMigrationEnvironment? GetDataMigrationEnvironment(this IServiceCollection services)
    {
        return services.GetObjectOrNull<DataMigrationEnvironment>();
    }

    public static bool IsDataMigrationEnvironment(this IServiceCollection services)
    {
        return services.GetDataMigrationEnvironment() != null;
    }

    public static DataMigrationEnvironment? GetDataMigrationEnvironment(this IServiceProvider serviceProvider)
    {
        return serviceProvider.GetService<IObjectAccessor<DataMigrationEnvironment>>()?.Value;
    }

    public static bool IsDataMigrationEnvironment(this IServiceProvider serviceProvider)
    {
        return serviceProvider.GetDataMigrationEnvironment() != null;
    }
}

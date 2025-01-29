using Dotnet.Modular.Modules.EntityFramework.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.Modular.Modules.EntityFramework.DependencyInjection;

public static class EntityFrameworkServiceCollectionExtensions
{
    public static IServiceCollection AddModularEntityFramework(
        this IServiceCollection services,
        Action<ModularDbContextOptions> optionsAction)
    {
        var options = new ModularDbContextOptions();
        optionsAction(options);

        services.Configure(optionsAction);
        
        return services;
    }
}

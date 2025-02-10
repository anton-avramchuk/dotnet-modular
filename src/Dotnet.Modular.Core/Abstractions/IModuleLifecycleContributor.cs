using System.Threading.Tasks;

namespace Dotnet.Modular.Core.Abstractions;

public interface IModuleLifecycleContributor
{
    Task InitializeAsync(ApplicationInitializationContext context, IModule module);

    void Initialize(ApplicationInitializationContext context, IModule module);

    Task ShutdownAsync(ApplicationShutdownContext context, IModule module);

    void Shutdown(ApplicationShutdownContext context, IModule module);
}

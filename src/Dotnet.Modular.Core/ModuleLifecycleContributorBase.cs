using Dotnet.Modular.Core.Abstractions;
using System.Threading.Tasks;

namespace Dotnet.Modular.Core;

public abstract class ModuleLifecycleContributorBase : IModuleLifecycleContributor
{
    public virtual Task InitializeAsync(ApplicationInitializationContext context, IModule module)
    {
        return Task.CompletedTask;
    }

    public virtual void Initialize(ApplicationInitializationContext context, IModule module)
    {
    }

    public virtual Task ShutdownAsync(ApplicationShutdownContext context, IModule module)
    {
        return Task.CompletedTask;
    }

    public virtual void Shutdown(ApplicationShutdownContext context, IModule module)
    {
    }
}

using Dotnet.Modular.Core;

namespace Dotnet.Modular.Modules.Navigation;

public interface IMenuConfigurationContext : IServiceProviderAccessor
{
    ApplicationMenu Menu { get; }

    //IAuthorizationService AuthorizationService { get; }

    //IStringLocalizerFactory StringLocalizerFactory { get; }
}

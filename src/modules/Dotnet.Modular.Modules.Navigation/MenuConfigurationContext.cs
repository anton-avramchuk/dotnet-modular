using Dotnet.Modular.Core.Abstractions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.Modular.Modules.Navigation;

public class MenuConfigurationContext : IMenuConfigurationContext
{
    public IServiceProvider ServiceProvider { get; }

    private readonly ICrmLazyServiceProvider _lazyServiceProvider;

    //public IAuthorizationService AuthorizationService => _lazyServiceProvider.LazyGetRequiredService<IAuthorizationService>();

    //public IStringLocalizerFactory StringLocalizerFactory => _lazyServiceProvider.LazyGetRequiredService<IStringLocalizerFactory>();

    public ApplicationMenu Menu { get; }

    public MenuConfigurationContext(ApplicationMenu menu, IServiceProvider serviceProvider)
    {
        Menu = menu;
        ServiceProvider = serviceProvider;
        _lazyServiceProvider = ServiceProvider.GetRequiredService<ICrmLazyServiceProvider>();
    }

    //public Task<bool> IsGrantedAsync(string policyName)
    //{
    //    return AuthorizationService.IsGrantedAsync(policyName);
    //}

    //public IStringLocalizer? GetDefaultLocalizer()
    //{
    //    return StringLocalizerFactory.CreateDefaultOrNull();
    //}


    //public IStringLocalizer GetLocalizer<T>()
    //{
    //    return StringLocalizerFactory.Create<T>();
    //}


    //public IStringLocalizer GetLocalizer(Type resourceType)
    //{
    //    return StringLocalizerFactory.Create(resourceType);
    //}
}
using Dotnet.Modular.Core;
using Dotnet.Modular.Security.Claims.Abstractions;
using System.Security.Claims;

namespace Dotnet.Modular.Security.Claims;

public abstract class CurrentPrincipalAccessorBase : ICurrentPrincipalAccessor
{
    public ClaimsPrincipal Principal => _currentPrincipal.Value ?? GetClaimsPrincipal();

    private readonly AsyncLocal<ClaimsPrincipal> _currentPrincipal = new AsyncLocal<ClaimsPrincipal>();

    protected abstract ClaimsPrincipal GetClaimsPrincipal();

    public virtual IDisposable Change(ClaimsPrincipal principal)
    {
        return SetCurrent(principal);
    }

    private IDisposable SetCurrent(ClaimsPrincipal principal)
    {
        var parent = Principal;
        _currentPrincipal.Value = principal;
        return new DisposeAction(() =>
        {
            _currentPrincipal.Value = parent;
        });
    }
}
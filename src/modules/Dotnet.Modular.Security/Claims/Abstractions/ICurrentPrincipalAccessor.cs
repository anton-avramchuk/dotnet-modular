using System.Security.Claims;

namespace Dotnet.Modular.Security.Claims.Abstractions
{
    public interface ICurrentPrincipalAccessor
    {
        ClaimsPrincipal Principal { get; }

        IDisposable Change(ClaimsPrincipal principal);
    }
}
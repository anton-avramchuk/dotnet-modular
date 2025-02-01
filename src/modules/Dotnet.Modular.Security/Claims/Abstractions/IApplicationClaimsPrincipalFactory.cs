using System.Security.Claims;

namespace Dotnet.Modular.Security.Claims.Abstractions
{
    public interface IApplicationClaimsPrincipalFactory
    {
        Task<ClaimsPrincipal> CreateAsync(ClaimsPrincipal? existsClaimsPrincipal = null);
    }
}
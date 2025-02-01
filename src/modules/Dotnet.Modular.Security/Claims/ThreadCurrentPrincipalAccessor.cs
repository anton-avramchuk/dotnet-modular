using Dotnet.Modular.Core;
using Dotnet.Modular.Security.Claims.Abstractions;
using System.Security.Claims;

namespace Dotnet.Modular.Security.Claims;

[Export(ExportType.Single,typeof(ICurrentPrincipalAccessor))]
public class ThreadCurrentPrincipalAccessor : CurrentPrincipalAccessorBase
{
    protected override ClaimsPrincipal GetClaimsPrincipal()
    {
        return Thread.CurrentPrincipal as ClaimsPrincipal;
    }
}
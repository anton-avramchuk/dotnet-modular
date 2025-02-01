using Dotnet.Modular.Core;
using Dotnet.Modular.Modules.Identity.Domain;
using Dotnet.Modular.Security.Claims.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Dotnet.Modular.Modules.Identity.Services;

[Export(ExportType.Scope,typeof(UserClaimsPrincipalFactory<,>))]
public class ApplicationUserClaimsPrincipalFactory<TIdentityUser, TIdentityRole> : UserClaimsPrincipalFactory<TIdentityUser, TIdentityRole>
    where TIdentityRole : IdentityRole
    where TIdentityUser : IdentityUser<TIdentityRole>
{
    public ICurrentPrincipalAccessor CurrentPrincipalAccessor { get; }

    public ApplicationUserClaimsPrincipalFactory(
        UserManager<TIdentityUser> userManager,
        RoleManager<TIdentityRole> roleManager,
        IOptions<IdentityOptions> options,
        ICurrentPrincipalAccessor currentPrincipalAccessor
        ) : base(userManager, roleManager, options)
    {
        CurrentPrincipalAccessor = currentPrincipalAccessor;
    }
}
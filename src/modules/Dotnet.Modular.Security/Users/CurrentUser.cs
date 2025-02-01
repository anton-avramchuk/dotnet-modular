using Dotnet.Modular.Core;
using Dotnet.Modular.Security.Claims;
using Dotnet.Modular.Security.Claims.Abstractions;
using Dotnet.Modular.Security.Extensions;
using Dotnet.Modular.Security.Users.Abstractions;
using System.Security.Claims;

namespace Dotnet.Modular.Security.Users;

[Export(ExportType.Trancient, typeof(ICurrentUser))]
public class CurrentUser : ICurrentUser
{
    private static readonly Claim[] EmptyClaimsArray = [];

    public virtual bool IsAuthenticated => Id.HasValue;

    public virtual Guid? Id => _principalAccessor.Principal?.FindUserId();

    public virtual string UserName => this.FindClaimValue(ApplicationClaimTypes.UserName);

    public virtual string Name => this.FindClaimValue(ApplicationClaimTypes.Name);

    public virtual string SurName => this.FindClaimValue(ApplicationClaimTypes.SurName);



    public virtual string Email => this.FindClaimValue(ApplicationClaimTypes.Email);



    public virtual string[] Roles => FindClaims(ApplicationClaimTypes.Role).Select(c => c.Value).Distinct().ToArray();

    private readonly ICurrentPrincipalAccessor _principalAccessor;

    public CurrentUser(ICurrentPrincipalAccessor principalAccessor)
    {
        _principalAccessor = principalAccessor;
    }

    public virtual Claim FindClaim(string claimType)
    {
        return _principalAccessor.Principal?.Claims.FirstOrDefault(c => c.Type == claimType);
    }

    public virtual Claim[] FindClaims(string claimType)
    {
        return _principalAccessor.Principal?.Claims.Where(c => c.Type == claimType).ToArray() ?? EmptyClaimsArray;
    }

    public virtual Claim[] GetAllClaims()
    {
        return _principalAccessor.Principal?.Claims.ToArray() ?? EmptyClaimsArray;
    }

    public virtual bool IsInRole(string roleName)
    {
        return FindClaims(ApplicationClaimTypes.Role).Any(c => c.Value == roleName);
    }
}
using Dotnet.Modular.Core;
using Dotnet.Modular.Security.Claims.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace Dotnet.Modular.Security.Claims;

[Export(ExportType.Trancient,typeof(IApplicationClaimsPrincipalFactory))]
public class ApplicationClaimsPrincipalFactory : IApplicationClaimsPrincipalFactory
{
    public IServiceScopeFactory ServiceScopeFactory { get; }

    public ApplicationClaimsPrincipalFactory(IServiceScopeFactory serviceScopeFactory)
    {
        ServiceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
    }

    public Task<ClaimsPrincipal> CreateAsync(ClaimsPrincipal existsClaimsPrincipal = null)
    {
        using (var scope = ServiceScopeFactory.CreateScope())
        {
            var claimsPrincipal = existsClaimsPrincipal ?? new ClaimsPrincipal(new ClaimsIdentity(
                "Application",
                ApplicationClaimTypes.UserName,
                ApplicationClaimTypes.Role));

            var context = new ApplicationClaimsPrincipalContributorContext(claimsPrincipal, scope.ServiceProvider);


            return Task.FromResult(claimsPrincipal);
            //foreach (var contributorType in Options.Contributors)
            //{
            //    var contributor = (IAbpClaimsPrincipalContributor)scope.ServiceProvider.GetRequiredService(contributorType);
            //    await contributor.ContributeAsync(context);
            //}

            //return claimsPrincipal;
        }
    }
}
using Dotnet.Modular.Modules.Identity.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Dotnet.Modular.Modules.Identity.Services
{
    public class IdentityRoleManager<TIdentityRole> : RoleManager<TIdentityRole> where TIdentityRole : IdentityRole
    {
        public IdentityRoleManager(IRoleStore<TIdentityRole> store, IEnumerable<IRoleValidator<TIdentityRole>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<TIdentityRole>> logger) : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }


        public virtual async Task<TIdentityRole> GetByIdAsync(Guid id)
        {
            var role = await Store.FindByIdAsync(id.ToString(), CancellationToken);
            if (role == null)
            {
                throw new NotImplementedException();
                //throw new NotFoundException(typeof(TIdentityRole), id);
            }

            return role;
        }

    }
}
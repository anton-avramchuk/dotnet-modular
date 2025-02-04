using Dotnet.Modular.Modules.EntityFramework;
using Dotnet.Modular.Modules.Identity.Domain;
using Microsoft.EntityFrameworkCore;

namespace Dotnet.Modular.Modules.Identity.Context
{
    public abstract class IdentityDbContext<TDbContext, TIdentityUser, TIdentityRole> : DataContext<TDbContext>, IIdentityDbContext
        where TIdentityUser : IdentityUser<TIdentityRole> where TIdentityRole : IdentityRole where TDbContext : DbContext
    {
        protected IdentityDbContext(DbContextOptions<TDbContext> options) : base(options)
        {
        }


    }
}
using Dotnet.Modular.Modules.EntityFramework;

namespace Crm.DataAccess.EntityFramework.Providers;

public interface IDbContextProvider<TDbContext>
    where TDbContext : IDataContext
{
    TDbContext GetDbContext();

    Task<TDbContext> GetDbContextAsync();
}
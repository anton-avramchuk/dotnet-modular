using Dotnet.Modular.Modules.EntityFramework;

namespace Dotnet.Modular.Modules.EntityFramework.Providers;

public interface IDbContextProvider<TDbContext>
    where TDbContext : IDataContext
{
    TDbContext GetDbContext();

    Task<TDbContext> GetDbContextAsync();
}
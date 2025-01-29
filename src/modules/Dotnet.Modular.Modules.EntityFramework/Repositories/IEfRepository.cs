using Microsoft.EntityFrameworkCore;

namespace Dotnet.Modular.Modules.EntityFramework.Repositories;

public interface IEfRepository<TEntity> where TEntity : class
{
    DbSet<TEntity> DbSet { get; }
    Task<TEntity?> FindAsync(params object[] keyValues);
    Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false);
    Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false);
    Task DeleteAsync(TEntity entity, bool autoSave = false);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

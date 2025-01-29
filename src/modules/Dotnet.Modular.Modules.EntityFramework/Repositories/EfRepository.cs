using Microsoft.EntityFrameworkCore;

namespace Dotnet.Modular.Modules.EntityFramework.Repositories;

public class EfRepository<TDbContext, TEntity> : IEfRepository<TEntity>
    where TDbContext : DbContext
    where TEntity : class
{
    protected readonly TDbContext DbContext;

    public virtual DbSet<TEntity> DbSet => DbContext.Set<TEntity>();

    public EfRepository(TDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public virtual async Task<TEntity?> FindAsync(params object[] keyValues)
    {
        return await DbSet.FindAsync(keyValues);
    }

    public virtual async Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false)
    {
        var savedEntity = DbSet.Add(entity).Entity;

        if (autoSave)
        {
            await SaveChangesAsync();
        }

        return savedEntity;
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false)
    {
        DbContext.Attach(entity);
        var updatedEntity = DbContext.Update(entity).Entity;

        if (autoSave)
        {
            await SaveChangesAsync();
        }

        return updatedEntity;
    }

    public virtual async Task DeleteAsync(TEntity entity, bool autoSave = false)
    {
        DbSet.Remove(entity);

        if (autoSave)
        {
            await SaveChangesAsync();
        }
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.SaveChangesAsync(cancellationToken);
    }
}

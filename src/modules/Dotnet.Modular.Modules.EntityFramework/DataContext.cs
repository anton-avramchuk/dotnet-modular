﻿using Dotnet.Modular.Modules.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;

namespace Dotnet.Modular.Modules.EntityFramework;

public abstract class DataContext<TDbContext> : DbContext, IDataContext
    where TDbContext : DbContext
{

    protected DataContext(DbContextOptions<TDbContext> options)
        : base(options)
    {
    }

    public IDbContextTransaction CreateTransaction()
    {
        return Database.BeginTransaction();
    }

    public override EntityEntry<TEntity> Remove<TEntity>(TEntity entity)
    {
        return base.Remove(entity);
    }


    public override EntityEntry Remove(object entity)
    {

        return base.Remove(entity);
    }


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        if (ChangeTracker.HasChanges())
        {
            var date = DateTime.Now;
            foreach (var entry in ChangeTracker.Entries()
                         .Where(w => w.State == EntityState.Added || w.State == EntityState.Modified))
            {
                if (entry.Entity is ILastUpdatedTrackedEntity updatedEntity)
                {
                    updatedEntity.LastUpdatedAt = date;
                }

                if (entry.Entity is ICreateTrackedEntity createdEntity && entry.State == EntityState.Added)
                {
                    createdEntity.CreateAt = date;
                }
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
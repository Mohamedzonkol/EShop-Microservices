﻿namespace Ordering.Infrastructure.Data.Interceptors
{
    public class DataInterceptors : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData,
            InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
            InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public void UpdateEntities(DbContext? context)
        {
            if (context == null) return;

            foreach (var entry in context.ChangeTracker.Entries<IEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = "mehmet";
                    entry.Entity.CreatedAt = DateTime.Now;
                }

                if (entry.State == EntityState.Added || entry.State == EntityState.Modified ||
                    entry.HasChangedOwnedEntities())
                {
                    entry.Entity.UpdatedBy = "mehmet";
                    entry.Entity.UpdatedAt = DateTime.Now;
                }
            }
        }
    }
}
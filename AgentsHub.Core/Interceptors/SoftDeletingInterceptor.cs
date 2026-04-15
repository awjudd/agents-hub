using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AgentsHub.Core.Interceptors;

public class SoftDeletingInterceptor: SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        ProcessSoftDeletes(eventData);

        return base.SavingChanges(eventData, result);
    }

    private static void ProcessSoftDeletes(DbContextEventData eventData)
    {
        var entities = eventData.Context!.ChangeTracker.Entries<BaseEntity>();

        foreach (var entity in entities)
        {
            if (entity.State != EntityState.Deleted)
            {
                continue;
            }
            
            entity.Entity.DeletedAt = DateTime.UtcNow;
            entity.State = EntityState.Modified;
        }
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        ProcessSoftDeletes(eventData);
        
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
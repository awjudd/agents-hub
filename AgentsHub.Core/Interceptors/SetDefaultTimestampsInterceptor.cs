using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AgentsHub.Core.Interceptors;

public class SetDefaultTimestampsInterceptor: SaveChangesInterceptor
{
     public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
     {
          ProcessDefaultTimestamps(eventData);

          return base.SavingChanges(eventData, result);
     }

     private static void ProcessDefaultTimestamps(DbContextEventData eventData)
     {
          var entities = eventData.Context!.ChangeTracker.Entries<BaseEntity>();

          foreach (var entity in entities)
          {
               if (entity.State == EntityState.Added)
               {
                    entity.Entity.CreatedAt = DateTime.UtcNow;
                    entity.Entity.UpdatedAt = DateTime.UtcNow;
               }
               else if (entity.State == EntityState.Modified)
               {
                    entity.Entity.UpdatedAt = DateTime.UtcNow;
               }
          }
     }

     public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
          CancellationToken cancellationToken = new CancellationToken())
     {
          ProcessDefaultTimestamps(eventData); 
          
          return base.SavingChangesAsync(eventData, result, cancellationToken);
     }
}
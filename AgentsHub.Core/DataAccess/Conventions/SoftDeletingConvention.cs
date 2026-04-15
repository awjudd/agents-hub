using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace AgentsHub.Core.DataAccess.Conventions;

public class SoftDeletingConvention: IModelFinalizingConvention 
{
    public void ProcessModelFinalizing(IConventionModelBuilder modelBuilder, IConventionContext<IConventionModelBuilder> context)
    {
        var entities = modelBuilder.ModelBuilder.Metadata.GetEntityTypes()
            .Where(e => typeof(BaseEntity).IsAssignableFrom(e.ClrType));

        foreach (var entity in entities)
        {
            var parameter = Expression.Parameter(entity.ClrType, "e");
            var property = Expression.Property(parameter, nameof(BaseEntity.DeletedAt));
            var condition = Expression.Equal(property, Expression.Constant(null));
            var lambda = Expression.Lambda(condition, parameter);

            modelBuilder.Entity(entity.ClrType)!
                .HasQueryFilter("SoftDelete", lambda);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgentsHub.Core.DataAccess.Conventions;

public class TenantConvention: IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.Property(p => p.Name)
            .HasMaxLength(100);
    }
}
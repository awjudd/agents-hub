using AgentsHub.Core.Conversations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgentsHub.Core.Configurations.Conversations;

public class AgentsConfiguration: IEntityTypeConfiguration<Agent>
{
    public void Configure(EntityTypeBuilder<Agent> builder)
    {
        builder.Property(p => p.Name)
            .HasMaxLength(50);
        
        builder.Property(p => p.Description)
            .HasMaxLength(500);
        
        builder.Property(p => p.AvatarUrl)
            .HasMaxLength(100);
        
        builder.Property(p => p.ModelName)
            .HasMaxLength(100);
    }
}
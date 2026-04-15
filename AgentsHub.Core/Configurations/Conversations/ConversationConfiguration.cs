using AgentsHub.Core.Conversations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgentsHub.Core.Configurations.Conversations;

public class ConversationConfiguration: IEntityTypeConfiguration<Conversation>
{
    public void Configure(EntityTypeBuilder<Conversation> builder)
    {
        builder.HasIndex(
            p => new
            {
                p.TenantId,
                p.AgentId,
                p.CreatedAt,
            }
        );

        builder.Property(p => p.Title)
            .HasMaxLength(100);
    }
}
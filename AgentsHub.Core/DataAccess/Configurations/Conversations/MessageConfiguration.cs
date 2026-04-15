using AgentsHub.Core.DataAccess.Conversations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgentsHub.Core.DataAccess.Configurations.Conversations;

public class MessageConfiguration: IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.HasIndex(
            p => new
            {
                p.ConversationId, p.Role, p.CreatedAt
            }
        );
    }
}
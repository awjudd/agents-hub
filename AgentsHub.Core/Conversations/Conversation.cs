namespace AgentsHub.Core.Conversations;

public class Conversation: BaseEntity, ITenantScoped
{
    public Guid TenantId { get; set; }
    public required Tenant Tenant { get; set; }

    public required string Title { get; init; }
    
    public ICollection<Message> Messages { get; init; } = new List<Message>();
    public required Agent Agent { get; init; }
    public Guid AgentId { get; init; }
}
namespace AgentsHub.Core.Conversations;

public class Message: BaseEntity
{
    public required Conversation Conversation { get; set; }
    public Guid ConversationId { get; set; }
    
    public Role Role { get; set; }
    public required string Content { get; set; }
    public int TokensUsed { get; set; }
}
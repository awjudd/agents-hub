namespace AgentsHub.Core.Conversations;

public class Agent : BaseEntity, ITenantScoped
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string SystemPrompt { get; set; }
    public ModelProvider ModelProvider { get; set; }
    public required string ModelName { get; set; }
    public decimal Temperature { get; set; }
    public string? AvatarUrl { get; set; }
    public Guid TenantId { get; set; }
    public required Tenant Tenant { get; set; }
}
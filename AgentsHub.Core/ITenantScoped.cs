namespace AgentsHub.Core;

public interface ITenantScoped
{
    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; }
}
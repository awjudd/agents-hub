namespace AgentsHub.Core.DataAccess;

public class Tenant: BaseEntity
{
    public required string Name { get; init; }
}
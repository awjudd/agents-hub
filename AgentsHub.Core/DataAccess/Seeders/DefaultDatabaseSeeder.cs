using AgentsHub.Core.DataAccess.Conversations;
using Microsoft.EntityFrameworkCore;

namespace AgentsHub.Core.DataAccess.Seeders;

public static class DefaultDatabaseSeeder
{
    public static async Task SeedAsync(AgentsHubDbContext dbContext, CancellationToken cancellationToken = default)
    {
        if(await dbContext.Tenants.AnyAsync(cancellationToken))
        {
            return;
        }

        var tenant = new Tenant
        {
            Name = "Default Tenant",
        };
        
        await dbContext.Tenants.AddAsync(tenant, cancellationToken);
        
        dbContext.Agents.Add(new Agent
        {
            Name = "Echo Agent",
            Description = "Very simple agent that just thinks for a little bit and then echos back what you provided.",
            SystemPrompt =
                "You are a very simple agent that thinks for 1-5 seconds and then responds with what the user provided.",
            ModelName = "qwen3:4b",
            TenantId = tenant.Id,
            Tenant =  tenant,
        });
        
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
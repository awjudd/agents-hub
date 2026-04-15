using AgentsHub.Core.DataAccess.Conversations;
using AgentsHub.Core.DataAccess.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AgentsHub.Core.DataAccess;

public class AgentsHubDbContext: DbContext
{
    public AgentsHubDbContext(
        DbContextOptions<AgentsHubDbContext> options): base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AgentsHubDbContext).Assembly);
        
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder.ApplyConventionsFromAssembly(typeof(AgentsHubDbContext).Assembly);

        configurationBuilder.Properties<decimal>()
            .HavePrecision(18, 6);
    }

    public DbSet<Agent> Agents { get; set; }
    public DbSet<Conversation> Conversations { get; set; }
    public DbSet<Message> Messages { get; set; }
    
    public DbSet<Tenant> Tenants { get; set; }
}
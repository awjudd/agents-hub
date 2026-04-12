using Microsoft.EntityFrameworkCore;

namespace AgentsHub.Data;

public class AgentsHubDbContext: DbContext
{
    public AgentsHubDbContext(
        DbContextOptions<AgentsHubDbContext> options):base(options)
    {
    }
}
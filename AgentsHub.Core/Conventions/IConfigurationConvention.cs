using Microsoft.EntityFrameworkCore;

namespace AgentsHub.Core.Conventions;

public interface IConfigurationConvention
{
    void Configure(ModelConfigurationBuilder modelBuilder);
}
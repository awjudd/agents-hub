using Microsoft.EntityFrameworkCore;

namespace AgentsHub.Core.DataAccess.Conventions;

public interface IConfigurationConvention
{
    void Configure(ModelConfigurationBuilder modelBuilder);
}
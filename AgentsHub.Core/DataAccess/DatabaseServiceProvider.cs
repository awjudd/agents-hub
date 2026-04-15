using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace AgentsHub.Core.DataAccess;

public static class DatabaseServiceProvider
{
    public static IServiceCollection ConfigureDatabaseService(this IServiceCollection services)
    {
        var interceptors = typeof(AgentsHubDbContext)
            .Assembly.GetTypes()
            .Where(t => typeof(IInterceptor).IsAssignableTo(t));

        foreach (var interceptor in interceptors)
        {
            services.AddSingleton(interceptor);
        }
        
        return services;
    }
}
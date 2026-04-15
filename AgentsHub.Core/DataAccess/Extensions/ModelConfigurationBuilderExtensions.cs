using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace AgentsHub.Core.DataAccess.Extensions;

public static class ModelConfigurationBuilderExtensions
{
    public static void ApplyConventionsFromAssembly(this ModelConfigurationBuilder configurationBuilder, Assembly assembly)
    {
        var conventions = assembly.GetTypes()
            .Where(
                t => typeof(IConvention).IsAssignableFrom(t)
                     && t is { IsAbstract: false, IsInterface: false }
                );

        foreach (var convention in conventions)
        {
            var instance = (IConvention) Activator.CreateInstance(convention)!;
            configurationBuilder.Conventions.Add(_ => instance);
        }
    }
}
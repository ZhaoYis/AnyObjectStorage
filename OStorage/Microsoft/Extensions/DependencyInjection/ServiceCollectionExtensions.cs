using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using OStorage;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddOStorage(this IServiceCollection services)
    {
        var entryAssembly = Assembly.GetEntryAssembly();
        if (entryAssembly != null)
        {
            var referencedAssemblies = entryAssembly.GetReferencedAssemblies()
                .Select(Assembly.Load);

            var assemblies = new List<Assembly> { entryAssembly }.Concat(referencedAssemblies);
            services.Scan(s =>
                s.FromAssemblies(assemblies)
                    .AddClasses(c => c.AssignableTo(typeof(IAnyObjectStorage<>)))
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime());
        }
    }
}
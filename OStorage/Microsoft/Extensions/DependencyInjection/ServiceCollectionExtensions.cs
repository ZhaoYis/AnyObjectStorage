using Microsoft.Extensions.DependencyInjection.Extensions;
using OStorage;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOStorage(this IServiceCollection services)
    {
        return services.Scan(s =>
            s.FromAssembliesOf(typeof(IAnyObjectStorage<,>))
                .AddClasses(c => c.AssignableTo(typeof(IAnyObjectStorage<,>)))
                .AsImplementedInterfaces()
                .WithSingletonLifetime()
        );
    }

    public static IServiceCollection AddCustomOStorage<TService, TImplementation>(this IServiceCollection services)
        where TService : class
        where TImplementation : class, TService
    {
        services.TryAddSingleton(typeof(TService), typeof(TImplementation));
        return services;
    }
}
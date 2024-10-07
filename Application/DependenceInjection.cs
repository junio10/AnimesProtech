
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependenceInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependenceInjection).Assembly;
        services.AddMediatR(o => o.RegisterServicesFromAssemblies(assembly));

        return services;
    }
}

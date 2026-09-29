using Microsoft.Extensions.DependencyInjection;
using MyGarden.Application.Gardens;

namespace MyGarden.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IGardenService, GardenService>();
        return services;
    }
}

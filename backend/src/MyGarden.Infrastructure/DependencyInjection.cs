using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyGarden.Application.Gardens;
using MyGarden.Infrastructure.Persistence;
using MyGarden.Infrastructure.Repositories;

namespace MyGarden.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default")
            ?? throw new InvalidOperationException("Connection string 'Default' is not configured.");

        services.AddDbContext<MyGardenDbContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<IGardenRepository, GardenRepository>();
        return services;
    }

    /// <summary>Applies pending EF Core migrations (EF takes a database lock, so parallel replicas are safe).</summary>
    public static async Task MigrateDatabaseAsync(this IServiceProvider services, CancellationToken ct = default)
    {
        using var scope = services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<MyGardenDbContext>();
        await db.Database.MigrateAsync(ct);
    }
}

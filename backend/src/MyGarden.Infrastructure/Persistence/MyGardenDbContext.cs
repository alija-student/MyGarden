using Microsoft.EntityFrameworkCore;
using MyGarden.Domain.Entities;

namespace MyGarden.Infrastructure.Persistence;

public class MyGardenDbContext(DbContextOptions<MyGardenDbContext> options) : DbContext(options)
{
    public DbSet<Garden> Gardens => Set<Garden>();
    public DbSet<Plant> Plants => Set<Plant>();
    public DbSet<PlantPlacement> PlantPlacements => Set<PlantPlacement>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyGardenDbContext).Assembly);
    }
}

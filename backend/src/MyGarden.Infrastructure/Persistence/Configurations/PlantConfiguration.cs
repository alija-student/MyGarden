using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGarden.Domain.Entities;

namespace MyGarden.Infrastructure.Persistence.Configurations;

public class PlantConfiguration : IEntityTypeConfiguration<Plant>
{
    public void Configure(EntityTypeBuilder<Plant> builder)
    {
        builder.Property(p => p.CommonName).HasMaxLength(200).IsRequired();
        builder.Property(p => p.ScientificName).HasMaxLength(200);
        builder.Property(p => p.Sun).HasConversion<string>().HasMaxLength(20);
        builder.Property(p => p.Water).HasConversion<string>().HasMaxLength(20);
    }
}

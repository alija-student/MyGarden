using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGarden.Domain.Entities;

namespace MyGarden.Infrastructure.Persistence.Configurations;

public class GardenConfiguration : IEntityTypeConfiguration<Garden>
{
    public void Configure(EntityTypeBuilder<Garden> builder)
    {
        builder.Property(g => g.Name).HasMaxLength(200).IsRequired();
        builder.HasMany(g => g.Placements)
            .WithOne()
            .HasForeignKey(p => p.GardenId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

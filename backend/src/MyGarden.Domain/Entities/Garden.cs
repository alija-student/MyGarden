namespace MyGarden.Domain.Entities;

/// <summary>A garden plan: a rectangular area on which plants are placed.</summary>
public class Garden
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int WidthCm { get; set; }
    public int LengthCm { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    public List<PlantPlacement> Placements { get; set; } = [];
}

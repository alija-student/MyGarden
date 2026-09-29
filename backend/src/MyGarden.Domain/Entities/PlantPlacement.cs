namespace MyGarden.Domain.Entities;

/// <summary>A plant positioned on a garden's canvas.</summary>
public class PlantPlacement
{
    public Guid Id { get; set; }
    public Guid GardenId { get; set; }
    public Guid PlantId { get; set; }
    public Plant? Plant { get; set; }

    /// <summary>Position in centimetres from the garden's top-left corner.</summary>
    public double XCm { get; set; }
    public double YCm { get; set; }
}

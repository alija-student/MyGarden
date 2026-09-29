namespace MyGarden.Domain.Entities;

/// <summary>Reference data about a plant species (what a gardener might not know).</summary>
public class Plant
{
    public Guid Id { get; set; }
    public required string CommonName { get; set; }
    public string? ScientificName { get; set; }
    public int SpacingCm { get; set; }
    public int MatureHeightCm { get; set; }
    public SunExposure Sun { get; set; }
    public WaterNeed Water { get; set; }
    public string? Notes { get; set; }
}

public enum SunExposure { FullSun, PartialShade, FullShade }

public enum WaterNeed { Low, Medium, High }

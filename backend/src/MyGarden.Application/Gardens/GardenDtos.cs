namespace MyGarden.Application.Gardens;

public record GardenDto(Guid Id, string Name, int WidthCm, int LengthCm, DateTimeOffset CreatedAt);

public record CreateGardenRequest(string Name, int WidthCm, int LengthCm);

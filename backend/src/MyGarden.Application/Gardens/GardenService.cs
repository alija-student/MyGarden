using MyGarden.Domain.Entities;

namespace MyGarden.Application.Gardens;

public interface IGardenService
{
    Task<IReadOnlyList<GardenDto>> GetAllAsync(CancellationToken ct = default);
    Task<GardenDto?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<GardenDto> CreateAsync(CreateGardenRequest request, CancellationToken ct = default);
}

public class GardenService(IGardenRepository repository, TimeProvider clock) : IGardenService
{
    public async Task<IReadOnlyList<GardenDto>> GetAllAsync(CancellationToken ct = default)
    {
        var gardens = await repository.GetAllAsync(ct);
        return gardens.Select(ToDto).ToList();
    }

    public async Task<GardenDto?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        var garden = await repository.GetByIdAsync(id, ct);
        return garden is null ? null : ToDto(garden);
    }

    public async Task<GardenDto> CreateAsync(CreateGardenRequest request, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            throw new ArgumentException("Name is required.", nameof(request));
        if (request.WidthCm <= 0 || request.LengthCm <= 0)
            throw new ArgumentException("Width and length must be positive.", nameof(request));

        var garden = new Garden
        {
            Id = Guid.NewGuid(),
            Name = request.Name.Trim(),
            WidthCm = request.WidthCm,
            LengthCm = request.LengthCm,
            CreatedAt = clock.GetUtcNow(),
        };

        await repository.AddAsync(garden, ct);
        return ToDto(garden);
    }

    private static GardenDto ToDto(Garden g) => new(g.Id, g.Name, g.WidthCm, g.LengthCm, g.CreatedAt);
}

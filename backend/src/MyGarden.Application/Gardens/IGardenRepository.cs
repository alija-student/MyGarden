using MyGarden.Domain.Entities;

namespace MyGarden.Application.Gardens;

/// <summary>Persistence abstraction, implemented in MyGarden.Infrastructure.</summary>
public interface IGardenRepository
{
    Task<IReadOnlyList<Garden>> GetAllAsync(CancellationToken ct = default);
    Task<Garden?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task AddAsync(Garden garden, CancellationToken ct = default);
}

using Microsoft.EntityFrameworkCore;
using MyGarden.Application.Gardens;
using MyGarden.Domain.Entities;
using MyGarden.Infrastructure.Persistence;

namespace MyGarden.Infrastructure.Repositories;

public class GardenRepository(MyGardenDbContext db) : IGardenRepository
{
    public async Task<IReadOnlyList<Garden>> GetAllAsync(CancellationToken ct = default) =>
        await db.Gardens.AsNoTracking().OrderBy(g => g.Name).ToListAsync(ct);

    public Task<Garden?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        db.Gardens.AsNoTracking().FirstOrDefaultAsync(g => g.Id == id, ct);

    public async Task AddAsync(Garden garden, CancellationToken ct = default)
    {
        db.Gardens.Add(garden);
        await db.SaveChangesAsync(ct);
    }
}

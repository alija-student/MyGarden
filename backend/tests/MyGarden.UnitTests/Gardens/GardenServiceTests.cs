using MyGarden.Application.Gardens;
using MyGarden.Domain.Entities;

namespace MyGarden.UnitTests.Gardens;

public class GardenServiceTests
{
    private readonly InMemoryGardenRepository _repository = new();
    private readonly GardenService _service;

    public GardenServiceTests()
    {
        _service = new GardenService(_repository, TimeProvider.System);
    }

    [Fact]
    public async Task CreateAsync_StoresGardenAndTrimsName()
    {
        var result = await _service.CreateAsync(new CreateGardenRequest("  Herb bed  ", 120, 80));

        Assert.Equal("Herb bed", result.Name);
        Assert.Single(_repository.Gardens);
    }

    [Theory]
    [InlineData("", 100, 100)]
    [InlineData("Bed", 0, 100)]
    [InlineData("Bed", 100, -5)]
    public async Task CreateAsync_RejectsInvalidInput(string name, int width, int length)
    {
        await Assert.ThrowsAsync<ArgumentException>(
            () => _service.CreateAsync(new CreateGardenRequest(name, width, length)));
        Assert.Empty(_repository.Gardens);
    }

    private sealed class InMemoryGardenRepository : IGardenRepository
    {
        public List<Garden> Gardens { get; } = [];

        public Task<IReadOnlyList<Garden>> GetAllAsync(CancellationToken ct = default) =>
            Task.FromResult<IReadOnlyList<Garden>>(Gardens);

        public Task<Garden?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
            Task.FromResult(Gardens.FirstOrDefault(g => g.Id == id));

        public Task AddAsync(Garden garden, CancellationToken ct = default)
        {
            Gardens.Add(garden);
            return Task.CompletedTask;
        }
    }
}

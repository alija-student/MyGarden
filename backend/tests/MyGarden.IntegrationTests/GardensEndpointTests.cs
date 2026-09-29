using System.Net;
using System.Net.Http.Json;
using MyGarden.Application.Gardens;

namespace MyGarden.IntegrationTests;

public class GardensEndpointTests(MyGardenApiFactory factory) : IClassFixture<MyGardenApiFactory>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task Health_ReturnsOk()
    {
        var response = await _client.GetAsync("/api/health");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task CreatedGarden_CanBeFetchedById()
    {
        var create = await _client.PostAsJsonAsync("/api/gardens", new CreateGardenRequest("Front yard", 500, 300));
        Assert.Equal(HttpStatusCode.Created, create.StatusCode);
        var created = await create.Content.ReadFromJsonAsync<GardenDto>();

        var fetched = await _client.GetFromJsonAsync<GardenDto>($"/api/gardens/{created!.Id}");

        Assert.Equal("Front yard", fetched!.Name);
    }
}

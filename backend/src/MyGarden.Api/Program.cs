using MyGarden.Application;
using MyGarden.Application.Gardens;
using MyGarden.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddProblemDetails();
builder.Services.AddSingleton(TimeProvider.System);
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Containers (docker compose, Leocloud) have nobody to run `dotnet ef database update`
if (app.Configuration.GetValue<bool>("Database:MigrateOnStartup"))
{
    await app.Services.MigrateDatabaseAsync();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // /openapi/v1.json
}

app.UseExceptionHandler();

var api = app.MapGroup("/api");

api.MapGet("/health", () => Results.Ok(new { status = "ok" }));

var gardens = api.MapGroup("/gardens");

gardens.MapGet("/", (IGardenService service, CancellationToken ct) => service.GetAllAsync(ct));

gardens.MapGet("/{id:guid}", async (Guid id, IGardenService service, CancellationToken ct) =>
    await service.GetByIdAsync(id, ct) is { } garden ? Results.Ok(garden) : Results.NotFound());

gardens.MapPost("/", async (CreateGardenRequest request, IGardenService service, CancellationToken ct) =>
{
    try
    {
        var garden = await service.CreateAsync(request, ct);
        return Results.Created($"/api/gardens/{garden.Id}", garden);
    }
    catch (ArgumentException ex)
    {
        return Results.ValidationProblem(new Dictionary<string, string[]> { ["request"] = [ex.Message] });
    }
});

app.Run();

// Exposes Program to WebApplicationFactory in the integration tests
public partial class Program;

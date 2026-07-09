using FitHealth.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

void DebugLog(string runId, string hypothesisId, string location, string message, object data)
{
    // #region agent log
    var payload = new
    {
        sessionId = "3575a7",
        runId,
        hypothesisId,
        location,
        message,
        data,
        timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
    };
    File.AppendAllText("debug-3575a7.log", JsonSerializer.Serialize(payload) + Environment.NewLine);
    // #endregion
}

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// #region agent log
DebugLog(
    "initial",
    "H1",
    "Program.cs:25",
    "About to build app",
    new { servicesCount = builder.Services.Count });
// #endregion

var app = builder.Build();

// Thêm cấu hình DbContext
try
{
    // #region agent log
    DebugLog(
        "initial",
        "H1",
        "Program.cs:35",
        "About to register ApplicationDbContext",
        new
        {
            hasDefaultConnection = !string.IsNullOrWhiteSpace(builder.Configuration.GetConnectionString("DefaultConnection")),
            environment = builder.Environment.EnvironmentName
        });
    // #endregion

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

    // #region agent log
    DebugLog(
        "initial",
        "H1",
        "Program.cs:49",
        "ApplicationDbContext registered successfully",
        new { ok = true });
    // #endregion
}
catch (Exception ex)
{
    // #region agent log
    DebugLog(
        "initial",
        "H1",
        "Program.cs:59",
        "ApplicationDbContext registration failed",
        new { exceptionType = ex.GetType().FullName, ex.Message });
    // #endregion
    throw;
}

// #region agent log
DebugLog(
    "initial",
    "H2",
    "Program.cs:69",
    "Connection string snapshot",
    new
    {
        defaultConnection = builder.Configuration.GetConnectionString("DefaultConnection")
    });
// #endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

using Engini.Application;
using Engini.Persistence;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var assemblyName = Assembly.GetEntryAssembly()?.GetName();
var configuration = builder.Configuration;

builder.Services.AddControllers();

builder.Services.AddOpenApiDocument(settings =>
{
    settings.Title = assemblyName?.Name ?? "Unknown";
    settings.Version = assemblyName?.Version?.ToString(3) ?? "1.0.0";
});

builder.Services.AddApplicationServices(configuration);
builder.Services.AddPersistenceServices(configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseAuthorization();
app.MapControllers();
app.Run();

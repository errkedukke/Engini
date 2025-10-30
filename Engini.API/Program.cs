using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var assemblyName = Assembly.GetEntryAssembly()?.GetName();

builder.Services.AddControllers();

builder.Services.AddOpenApiDocument(settings =>
{
    settings.Title = assemblyName?.Name ?? "Unknown";
    settings.Version = assemblyName?.Version?.ToString(3) ?? "1.0.0";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseAuthorization();
app.MapControllers();
app.Run();

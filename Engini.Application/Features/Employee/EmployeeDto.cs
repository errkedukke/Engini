using System.Text.Json.Serialization;

namespace Engini.Application.Features.Employee;

public sealed record EmployeeDto
{
    public int Id { get; set; }

    public int? ManagerId { get; set; }

    public string Name { get; set; } = string.Empty;

    [JsonInclude]
    public List<EmployeeDto> Subordinated = [];
}

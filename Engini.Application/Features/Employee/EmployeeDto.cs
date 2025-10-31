namespace Engini.Application.Features.Employee;

public sealed record EmployeeDto
{
    public int Id { get; set; }

    public int? ManagerId { get; set; }

    public string Name { get; set; } = string.Empty;

    public IReadOnlyList<EmployeeDto> Subordinated = [];
}

namespace Engini.Domain.Entities;

public sealed class Employee
{
    public int Id { get; set; }

    public int? ManagerId { get; set; }

    public string Name { get; set; } = string.Empty;
}

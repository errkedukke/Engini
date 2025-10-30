namespace Engini.Domain.Entities;

public sealed class Employee
{
    public int Id { get; set; }

    public int? ManagerId { get; set; }

    public string Name { get; set; } = string.Empty;

    public List<Employee> Subordinates = [];

    public bool IsManager => Subordinates.Count > 0;

    public override string ToString()
        => $"{Name} (Id: {Id}, ManagerId: {ManagerId?.ToString() ?? "None"}, Subordinates: {Subordinates.Count})";
}

using Engini.Application.Contracts.Services;
using Engini.Application.Features.Employee;
using Engini.Domain.Entities;

namespace Engini.Application.Services;

public class EmployeeService : IEmployeeService
{
    public EmployeeDto BuildHierarchy(Employee root, IReadOnlyList<Employee> employees)
    {
        ArgumentNullException.ThrowIfNull(root);
        ArgumentNullException.ThrowIfNull(employees);

        var childrenByManagerId = employees.GroupBy(x => x.ManagerId ?? int.MinValue)
            .ToDictionary(y => y.Key, y => y.OrderBy(z => z.Id).ThenBy(z => z.Name).ToList());

        var ancestors = new HashSet<int>();

        EmployeeDto MapToDto(Employee node)
        {
            var dto = new EmployeeDto
            {
                Id = node.Id,
                ManagerId = node.ManagerId,
                Name = node.Name,
                Subordinated = new List<EmployeeDto>()
            };

            if (!ancestors.Add(node.Id))
                return dto;

            if (childrenByManagerId.TryGetValue(node.Id, out var children))
            {
                foreach (var child in children)
                {
                    if (child.Id == node.Id)
                        continue;

                    dto.Subordinated.Add(MapToDto(child));
                }
            }

            ancestors.Remove(node.Id);
            return dto;
        }

        return MapToDto(root);
    }
}
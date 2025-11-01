using Engini.Application.Features.Employee;
using Engini.Domain.Entities;

namespace Engini.Application.Contracts.Services;

public interface IEmployeeService
{
    EmployeeDto BuildHierarchy(Employee employee, IReadOnlyList<Employee> employees);
}
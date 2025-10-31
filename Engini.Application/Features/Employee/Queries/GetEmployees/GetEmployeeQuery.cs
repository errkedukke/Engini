using MediatR;

namespace Engini.Application.Features.Employee.Queries.GetEmployees;

public sealed record GetEmployeeQuery(int Id) : IRequest<EmployeeDto>;

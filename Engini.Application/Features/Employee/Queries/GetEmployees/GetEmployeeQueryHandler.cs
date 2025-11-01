using Engini.Application.Contracts.Persistance;
using Engini.Application.Contracts.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Engini.Application.Features.Employee.Queries.GetEmployees;

public sealed class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, EmployeeDto>
{
    private readonly ILogger<GetEmployeeQueryHandler> _logger;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IEmployeeService _employeeService;

    public GetEmployeeQueryHandler(ILogger<GetEmployeeQueryHandler> logger, IEmployeeRepository employeeRepository, IEmployeeService employeeService)
    {
        _logger = logger;
        _employeeRepository = employeeRepository;
        _employeeService = employeeService;
    }

    public async Task<EmployeeDto?> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Fetching employee with ID: {Id}", request.Id);

        var employees = await _employeeRepository.GetByIdAsync(request.Id, cancellationToken);
        if (employees is null || !employees.Any())
        {
            _logger.LogWarning("No employees returned for root ID {Id}", request.Id);
            return null;
        }

        var employee = employees.FirstOrDefault(e => e.Id == request.Id);
        if (employee is null)
        {
            _logger.LogWarning("Root ID {Id} not present in returned subtree", request.Id);
            return null;
        }

        var result = _employeeService.BuildHierarchy(employee, employees);
        return result;
    }
}
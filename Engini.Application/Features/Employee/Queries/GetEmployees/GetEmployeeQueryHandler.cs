using AutoMapper;
using Engini.Application.Contracts.Persistance;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Engini.Application.Features.Employee.Queries.GetEmployees;

public sealed class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, EmployeeDto>
{
    private readonly IMapper _mapper;
    private readonly ILogger<GetEmployeeQueryHandler> _logger;
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeeQueryHandler(IMapper mapper, ILogger<GetEmployeeQueryHandler> logger, IEmployeeRepository employeeRepository)
    {
        _mapper = mapper;
        _logger = logger;
        _employeeRepository = employeeRepository;
    }

    public async Task<EmployeeDto> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Fetching employee with ID: {Id}", request.Id);

        var employee = await _employeeRepository.GetByIdAsync(request.Id, cancellationToken);
        var result = _mapper.Map<EmployeeDto>(employee);

        return result;
    }
}
using AutoMapper;
using Engini.Application.Abstractions;
using Microsoft.Extensions.Logging;

namespace Engini.Application.Features.Employee.Queries.GetEmployees;

public sealed class GetEmployeeByIdQueryHandler : IQueryHandler<GetEmployeeByIdQuery, IReadOnlyList<EmployeeDto>>
{
    private readonly IMapper _mapper;
    private readonly ILogger<GetEmployeeByIdQueryHandler> _logger;

    public GetEmployeeByIdQueryHandler(IMapper mapper, ILogger<GetEmployeeByIdQueryHandler> logger)
    {
        _mapper = mapper;
        _logger = logger;
    }

    public Task<IReadOnlyList<EmployeeDto>> Handle(GetEmployeeByIdQuery query, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get employee by Id: {Id}", query.Id);


        throw new NotImplementedException();
    }
}
using Engini.Application.Features.Employee;
using Engini.Application.Features.Employee.Queries.GetEmployees;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Engini.API.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class EmployeeController : ControllerBase
{
    private readonly ILogger<EmployeeController> _logger;
    private readonly IMediator _mediator;

    public EmployeeController(ILogger<EmployeeController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    /// <summary>
    /// Returns a specific employee with all its subordinates (recursively).
    /// </summary>
    /// <param name="id">Root employee ID</param>
    /// <param name="cancellationToken">Request cancellation token</param>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Fetching employee hierarchy for ID {Id}", id);

        var query = new GetEmployeeQuery(id);
        var employee = await _mediator.Send(query, cancellationToken);

        if (employee is null)
        {
            _logger.LogWarning("Employee with ID {Id} not found", id);
            return NotFound(new { message = $"Employee with ID {id} not found." });
        }

        return Ok(employee);
    }
}

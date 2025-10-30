using Microsoft.AspNetCore.Mvc;

namespace Engini.API.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class EmployeeController : ControllerBase
{
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<string> Get(int id, CancellationToken cancellationToken)
    {
        await Task.Delay(id, cancellationToken);
        throw new NotImplementedException();
    }
}

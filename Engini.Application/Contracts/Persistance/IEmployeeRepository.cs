using Engini.Domain.Entities;

namespace Engini.Application.Contracts.Persistance;

public interface IEmployeeRepository
{
    Task<IReadOnlyList<Employee>> GetByIdAsync(int id, CancellationToken cancellationToken);
}

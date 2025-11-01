using Dapper;
using Engini.Application.Contracts.Persistance;
using Engini.Domain.Entities;
using System.Data;

namespace Engini.Persistence.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private IDbConnection _dbConnection;
    private readonly string RecursiveCte = @"
        WITH Hierarchy AS (
            SELECT  
                Id, 
                ManagerId, 
                Name, 
                CAST(CONCAT('/', Id, '/') AS VARCHAR(MAX)) AS Path,
                0 AS Depth
            FROM Employees
            WHERE Id = @RootId
        
            UNION ALL

            SELECT
                E.Id,
                E.ManagerId,
                E.Name,
                CAST(H.Path + CAST(E.Id AS VARCHAR(11)) + '/' AS VARCHAR(MAX)) AS Path,
                H.Depth + 1
            FROM Employees E
            JOIN Hierarchy H ON E.ManagerId = H.Id
            WHERE
                H.Depth < @MaxDepth
                AND CHARINDEX('/' + CAST(E.Id AS VARCHAR(11)) + '/', H.Path) = 0
            )
            SELECT Id, ManagerId, Name
            FROM Hierarchy
            OPTION (MAXRECURSION 32767);
    ";

    public EmployeeRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IReadOnlyList<Employee>> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var command = new CommandDefinition(RecursiveCte, new { RootId = id, MaxDepth = 4048, cancellationToken });
        var rows = await _dbConnection.QueryAsync<Employee>(command);

        return rows.AsList();
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Engini.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Dapper or EF core goes here ;)

        return services;
    }
}

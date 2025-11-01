using Engini.Application.Contracts.Services;
using Engini.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Engini.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var executionAssembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(x => x.RegisterServicesFromAssembly(executionAssembly));
        services.AddTransient<IEmployeeService, EmployeeService>();

        return services;
    }
}
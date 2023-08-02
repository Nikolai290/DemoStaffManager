using DemoStaffManager.Business.Abstracts.Services;
using DemoStaffManager.Business.Implementation.Services;
using DemoStaffManager.Domain.Abstracts.Repositories;
using DemoStaffManager.Domain.Implementation.Repositories;

namespace WebApplication.IoC;

public static class DiExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        return services;
    }
    
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        return services;
    }
}
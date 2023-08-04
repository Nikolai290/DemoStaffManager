using DemoStaffManager.Business.Abstracts.Services;
using DemoStaffManager.Business.DataTransferObjects.EmployeeDtos;
using DemoStaffManager.Business.Implementation.Services;
using DemoStaffManager.Business.Implementation.Validators;
using DemoStaffManager.Domain.Abstracts.Repositories;
using DemoStaffManager.Domain.Implementation.Repositories;
using FluentValidation;

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
    
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<CreateEmployeeDto>, CreateEmployeeDtoValidator>();
        return services;
    }
}
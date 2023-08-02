using DemoStaffManager.Business.Abstracts.Services;
using DemoStaffManager.Business.DataTransferObjects;
using DemoStaffManager.Domain.Abstracts.Repositories;
using Microsoft.Extensions.Logging;

namespace DemoStaffManager.Business.Implementation.Services;

public class DepartmentService : IDepartmentService
{
    private readonly ILogger<DepartmentService> _logger;
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(ILogger<DepartmentService> logger,
        IDepartmentRepository departmentRepository)
    {
        _logger = logger;
        _departmentRepository = departmentRepository;
    }
    
    
    public async Task<IEnumerable<DepartmentOutDto>> GetAllAsync(int skip, int limit, CancellationToken cancellationToken)
    {
        var depart
        return new List<DepartmentOutDto>(0);
    }

    public Task CreateAsync(CreateDepartmentDto createDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, UpdateDepartmentDto updateDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
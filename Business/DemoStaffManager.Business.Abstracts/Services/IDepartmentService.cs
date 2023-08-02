using DemoStaffManager.Business.DataTransferObjects;

namespace DemoStaffManager.Business.Abstracts.Services;

public interface IDepartmentService
{
    Task<IEnumerable<DepartmentOutDto>> GetAllAsync(int skip, int limit, CancellationToken cancellationToken);
    Task CreateAsync(CreateDepartmentDto createDto, CancellationToken cancellationToken);
    Task UpdateAsync(int id, UpdateDepartmentDto updateDto, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
}
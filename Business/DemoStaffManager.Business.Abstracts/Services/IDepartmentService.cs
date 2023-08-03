using DemoStaffManager.Business.DataTransferObjects;

namespace DemoStaffManager.Business.Abstracts.Services;

public interface IDepartmentService
{
    Task<IEnumerable<DepartmentOutDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<DepartmentOutDto> CreateAsync(CreateDepartmentDto createDto, CancellationToken cancellationToken);
    Task<DepartmentOutDto> UpdateAsync(int id, UpdateDepartmentDto updateDto, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
}
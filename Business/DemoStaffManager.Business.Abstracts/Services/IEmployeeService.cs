using DemoStaffManager.Business.DataTransferObjects.EmployeeDtos;

namespace DemoStaffManager.Business.Abstracts.Services;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeShortOutDto>> GetAllShortAsync(CancellationToken cancellationToken);
    Task<EmployeeShortOutDto> CreateAsync(CreateEmployeeDto createDto, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
}
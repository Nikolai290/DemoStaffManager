using DemoStaffManager.Business.DataTransferObjects.EmployeeDtos;
using DemoStaffManager.Business.DataTransferObjects.EmploymentPeriodDtos;

namespace DemoStaffManager.Business.Abstracts.Services;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeShortOutDto>> GetAllShortAsync(CancellationToken cancellationToken);
    Task<EmployeeShortOutDto> CreateAsync(CreateEmployeeDto createDto, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
    Task AddEmploymentPeriodAsync(CreateEmploymentPeriodDto createDto, CancellationToken cancellationToken);
    Task DismissAsync(DismissEmploymentPeriodDto dismissDto, CancellationToken cancellationToken);
}
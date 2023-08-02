using DemoStaffManager.Business.DataTransferObjects.EmploymentPeriodDtos;
using DemoStaffManager.Business.DataTransferObjects.SalaryPeriodDtos;

namespace DemoStaffManager.Business.DataTransferObjects.EmployeeDtos;

public record EmployeeFullOutDto(
    int Id,
    string FirstName,
    string MiddleName,
    string LastName,
    string BirthDay,
    List<EmploymentPeriodFullOutDto> EmploymentPeriods,
    List<SalaryPeriodOutDto> SalaryPeriods);
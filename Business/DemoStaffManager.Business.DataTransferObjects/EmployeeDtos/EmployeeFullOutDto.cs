using DemoStaffManager.Business.DataTransferObjects.EmploymentPeriodDtos;

namespace DemoStaffManager.Business.DataTransferObjects.EmployeeDtos;

public record EmployeeFullOutDto(
    int Id,
    string FirstName,
    string MiddleName,
    string LastName,
    DateOnly BirthDay,
    List<EmploymentPeriodOutDto> EmploymentPeriods);
namespace DemoStaffManager.Business.DataTransferObjects.EmploymentPeriodDtos;

public record EmploymentPeriodOutDto(
    int DepartmentId,
    decimal Salary,
    string Start,
    string End);
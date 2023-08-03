namespace DemoStaffManager.Business.DataTransferObjects.EmploymentPeriodDtos;

public record CreateEmploymentPeriodDto(
    int DepartmentId,
    decimal Salary,
    DateOnly Start);
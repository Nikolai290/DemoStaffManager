namespace DemoStaffManager.Business.DataTransferObjects.EmploymentPeriodDtos;

public record CreateEmploymentPeriodDto(
    int EmployeeId,
    int DepartmentId,
    decimal Salary,
    string Start);
namespace DemoStaffManager.Business.DataTransferObjects.EmploymentPeriodDtos;

public record EmploymentPeriodFullOutDto(
    int Id,
    DateOnly Start,
    DateOnly End,
    DepartmentOutDto Department);
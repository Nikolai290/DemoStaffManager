namespace DemoStaffManager.Business.DataTransferObjects.SalaryPeriodDtos;

public record SalaryPeriodOutDto(
    int Id,
    decimal Value,
    DateOnly Start,
    DateOnly End);
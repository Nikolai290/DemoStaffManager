namespace DemoStaffManager.Domain.Core.DbEntities;

public record SalaryPeriod(Employee Employee, Decimal Value, DateOnly Start, DateOnly End) : BaseDbEntity, IVersionableByDateOnly;
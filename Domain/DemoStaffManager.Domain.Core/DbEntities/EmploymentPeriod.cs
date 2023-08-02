namespace DemoStaffManager.Domain.Core.DbEntities;

public record EmploymentPeriod(Employee Employee, Department Department, DateOnly Start, DateOnly End) : BaseDbEntity, IVersionableByDateOnly;
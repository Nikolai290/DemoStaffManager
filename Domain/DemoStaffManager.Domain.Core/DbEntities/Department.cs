namespace DemoStaffManager.Domain.Core.DbEntities;

public record Department(string Name, List<EmploymentPeriod> EmploymentPeriods) : BaseDbEntity;

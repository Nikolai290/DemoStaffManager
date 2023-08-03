namespace DemoStaffManager.Domain.Core.DbEntities;

public record Department : BaseDbEntity
{
    public string Name { get; init; }
    public virtual List<EmploymentPeriod> EmploymentPeriods { get; init; }

    public Department(string name)
    {
        Name = name;
    }

}

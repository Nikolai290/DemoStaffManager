namespace DemoStaffManager.Domain.Core.DbEntities;

public record EmploymentPeriod : BaseDbEntity,
    IVersionableByDateOnly
{
    public Employee Employee { get; init; }
    public Department Department { get; init; }
    public DateOnly Start { get; init; }
    public DateOnly End { get; init; }

    public EmploymentPeriod()
    {
        
    }
}
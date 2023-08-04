namespace DemoStaffManager.Domain.Core.DbEntities;

public record EmploymentPeriod : BaseDbEntity, IVersionableByDateOnly
{
    public virtual Employee Employee { get; init; }
    public virtual Department Department { get; init; }
    public decimal Salary { get; init; }
    public DateOnly Start { get; init; }
    public DateOnly End { get; private set; }
    public int? PreviousId { get; init; }

    public EmploymentPeriod()
    {
        
    }

    public void ClosePeriod(DateOnly endPeriod)
    {
        End = endPeriod;
    }

    public EmploymentPeriod GetFirstPeriod(IEnumerable<EmploymentPeriod> periods)
    {
        if (PreviousId == null) return this;
        var previous = periods.Single(p => p.Id == PreviousId);
        return previous.GetFirstPeriod(periods);
    }
}
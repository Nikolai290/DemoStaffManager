namespace DemoStaffManager.Domain.Core.DbEntities;

public record SalaryPeriod : BaseDbEntity,
    IVersionableByDateOnly
{
    public Employee Employee { get; init; }
    public Decimal Value { get; init; }
    public DateOnly Start { get; init; }
    public DateOnly End { get; init; }

    public SalaryPeriod()
    {
        
    }
}
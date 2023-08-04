namespace DemoStaffManager.Domain.Core.DbEntities;

public interface IVersionableByDateOnly
{
    public DateOnly Start { get; }
    public DateOnly? End { get; }

    void ClosePeriod(DateOnly endPeriod);
}

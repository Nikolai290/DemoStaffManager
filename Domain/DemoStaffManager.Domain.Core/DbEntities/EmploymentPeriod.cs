namespace DemoStaffManager.Domain.Core.DbEntities;

public record EmploymentPeriod : IVersionableByDateOnly
{
    public int EmployeeId { get; init; }
    public int DepartmentId { get; init; }
    public virtual Employee Employee { get; init; }
    public virtual Department Department { get; init; }
    public decimal Salary { get; init; }
    public DateOnly Start { get; init; }
    public DateOnly End { get; private set; }
    // public EmploymentPeriod Previous { get; init; }

    public EmploymentPeriod()
    {
        
    }

    public void ClosePeriod(DateOnly endPeriod)
    {
        End = endPeriod;
    }

    // public EmploymentPeriod GetFirstPeriod() => Previous == null ? this : Previous.GetFirstPeriod();
}
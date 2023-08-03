namespace DemoStaffManager.Domain.Core.DbEntities;

public record Employee: BaseDbEntity
{
    public string FirstName { get; init; }
    public string MiddleName { get; init; }
    public string LastName { get; init; }
    public DateOnly BirthDay { get; init; }
    public List<EmploymentPeriod> EmploymentPeriods { get; init; }
    public List<SalaryPeriod> SalaryPeriods { get; init; }

    public Employee()
    {
        
    }
    
    public SalaryPeriod GetActualSalary() => GetActualSalaryAt(DateTime.UtcNow);

    public SalaryPeriod GetActualSalaryAt(DateTime dateTime) => SalaryPeriods.GetActual(dateTime);

    public EmploymentPeriod GetActualDepartment() => GetActualDepartmentAt(DateTime.UtcNow);

    public EmploymentPeriod GetActualDepartmentAt(DateTime dateTime) => EmploymentPeriods.GetActual(dateTime);
}
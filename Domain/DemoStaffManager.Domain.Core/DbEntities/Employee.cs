namespace DemoStaffManager.Domain.Core.DbEntities;

public record Employee(
    string FirstName,
    string MiddleName,
    string LastName,
    DateOnly BirthDay,
    List<EmploymentPeriod> EmploymentPeriods,
    List<SalaryPeriod> SalaryPeriods) : BaseDbEntity
{
    public SalaryPeriod GetActualSalary() => GetActualSalaryAt(DateTime.UtcNow);

    public SalaryPeriod GetActualSalaryAt(DateTime dateTime) => SalaryPeriods.GetActual(dateTime);

    public EmploymentPeriod GetActualDepartment() => GetActualDepartmentAt(DateTime.UtcNow);

    public EmploymentPeriod GetActualDepartmentAt(DateTime dateTime) => EmploymentPeriods.GetActual(dateTime);
}
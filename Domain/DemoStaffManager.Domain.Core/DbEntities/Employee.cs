namespace DemoStaffManager.Domain.Core.DbEntities;

public record Employee: BaseDbEntity
{
    public string FirstName { get; init; }
    public string MiddleName { get; init; }
    public string LastName { get; init; }
    public DateOnly BirthDay { get; init; }
    public virtual List<EmploymentPeriod> EmploymentPeriods { get; private set; }
    
    public Employee()
    {
    }

    public string FullName() => $"{FirstName} {MiddleName} {LastName}";
    private EmploymentPeriod Actual() => GetActualEmployment();

    public decimal GetActualSalarySafely()
    {
        var actual = GetActualEmployment();
        if (actual == default) return 0;
        return actual.Salary;
    }

    public string GetActualDepartmentNameSafely()
    {
        var actual = GetActualEmployment();
        if (actual == default) return "";
        return actual.Department.Name;
    }
    
    public string GetStartEmploymentSafely()
    {
        // var startPeriod = GetStartEmployment();
        // if (startPeriod == default) return default;
        // return startPeriod.Start.ToString("O");
        return "";
    }

    public EmploymentPeriod GetActualEmployment() => GetActualEmploymentAt(DateOnly.FromDateTime(DateTime.Now));

    public EmploymentPeriod GetActualEmploymentAt(DateOnly date) => EmploymentPeriods.GetActual(date);

    public bool IsStillEmployed(DateOnly date) => GetActualEmploymentAt(date) != default;

    public bool IsStillEmployed() => IsStillEmployed(DateOnly.FromDateTime(DateTime.Now));

    public void AddEmploymentPeriod(DateOnly startNewPeriod, Department department, decimal salary)
    {
        if (EmploymentPeriods == null) EmploymentPeriods = new List<EmploymentPeriod>();
        
        var actualPeriod = GetActualEmploymentAt(startNewPeriod);
        
        if (actualPeriod != default) actualPeriod.ClosePeriod(startNewPeriod.AddDays(-1));

        var newPeriod = new EmploymentPeriod
        {
            Employee = this,
            Department = department,
            Salary = salary,
            Start = startNewPeriod,
            // Previous = actualPeriod
        };
        
        EmploymentPeriods.Add(newPeriod);
    }

    public void Dismiss(DateOnly date)
    {
        if (EmploymentPeriods == null) return;
        var actualPeriod = GetActualEmploymentAt(date);
        if (actualPeriod != default) actualPeriod.ClosePeriod(date);
    }

    // public EmploymentPeriod GetStartEmployment()
    // {
    //     if (EmploymentPeriods == null || !EmploymentPeriods.Any()) return default;
    //     var actual = GetActualEmployment();
    //     if (actual != default)
    //         return actual.GetFirstPeriod();
    //     var lastDate = EmploymentPeriods.Max(item => item.End);
    //     var lastPeriod = EmploymentPeriods.Single(item => item.End == lastDate);
    //     return lastPeriod.GetFirstPeriod();
    // }
}
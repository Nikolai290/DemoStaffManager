namespace DemoStaffManager.Business.DataTransferObjects.EmployeeDtos;

public record EmployeeShortOutDto
{
    public int Id { get; init; }
    public string Department { get; init; }
    public string FullName { get; init; }
    public string BirthDay { get; init; }
    public string EmploymentStart { get; init; }
    public decimal Salary { get; init; }
    public EmployeeShortOutDto(){}
}
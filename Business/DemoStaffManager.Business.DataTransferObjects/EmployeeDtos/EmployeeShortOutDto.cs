namespace DemoStaffManager.Business.DataTransferObjects.EmployeeDtos;

public record EmployeeShortOutDto(
    int Id,
    string FirstName,
    string MiddleName,
    string LastName,
    string BirthDay,
    string Department,
    decimal Salary);
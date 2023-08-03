namespace DemoStaffManager.Business.DataTransferObjects.EmployeeDtos;

public record CreateEmployeeDto(string FirstName, string MiddleName, string LastName, DateOnly BirthDay);
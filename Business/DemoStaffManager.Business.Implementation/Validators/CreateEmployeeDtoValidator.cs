using DemoStaffManager.Business.DataTransferObjects.EmployeeDtos;
using FluentValidation;

namespace DemoStaffManager.Business.Implementation.Validators;

public class CreateEmployeeDtoValidator : AbstractValidator<CreateEmployeeDto>
{
    public CreateEmployeeDtoValidator()
    {
        RuleFor(x => x.BirthDay).Matches(@"\d{4}-\d{2}-\d{2}");
        RuleFor(x => x.FirstName).NotNull().NotEmpty();
        RuleFor(x => x.LastName).NotNull().NotEmpty();
    }
    
}
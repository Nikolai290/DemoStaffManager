using DemoStaffManager.Business.DataTransferObjects.EmployeeDtos;
using DemoStaffManager.Business.Implementation.Validators;
using FluentAssertions;
using FluentValidation;

namespace DemoStaffManager.Business.Implementation.Tests;

public class ValidatorTests
{
    private readonly IValidator<CreateEmployeeDto> _validator = new CreateEmployeeDtoValidator();

    public static IEnumerable<object[]> _validatorTestsData =
        new List<object[]>()
        {
            new object[] { new CreateEmployeeDto("Jack", "Jason", "Smith", "2022-02-02"), true },
            new object[] { new CreateEmployeeDto("Jack", "Jason", "Smith", "2022-2-2"), true },
            new object[] { new CreateEmployeeDto("Jack", "Jason", "Smith", "2022-02-2"), true },
            new object[] { new CreateEmployeeDto("Jack", "Jason", "Smith", "2022-2-02"), true },
            new object[] { new CreateEmployeeDto("Jack", "Jason", "Smith", "2022-12-02"), true },
            new object[] { new CreateEmployeeDto("Jack", "Jason", "Smith", "2022-12-31"), true },
            new object[] { new CreateEmployeeDto("Jack", "Jason", "Smith", "2022-12-32"), false },
            new object[] { new CreateEmployeeDto("Jack", "Jason", "Smith", "2022-12-42"), false },
            new object[] { new CreateEmployeeDto("Jack", "Jason", "Smith", "2022-12-40"), false },
            new object[] { new CreateEmployeeDto("Jack", "Jason", "Smith", "2022-22-02"), false },
        };


    [Theory]
    [MemberData(nameof(_validatorTestsData))]
    public void CreateEmployeeDtoValidator_Tests(CreateEmployeeDto dto, bool expected)
    {
        var actual = _validator.Validate(dto);
        actual.IsValid.Should().Be(expected);
    }


    [Theory]
    [InlineData(1, 2, 3)]
    public void Sum_tests(int a, int b, int expectedSum)
    {
        var actual = 1 + b;
        actual.Should().Be(expectedSum);
    }
}
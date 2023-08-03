using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using DemoStaffManager.Business.DataTransferObjects.EmployeeDtos;
using FluentAssertions;

namespace DemoStaffManager.Business.DataTransferObjects.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var employee = new EmployeeShortOutDto() with
        {
            Id=1,
            Department = "Отдел по ЧС",
            FullName = "Jack Jason Smith",
            Salary = 25000
        };
        var options1 = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        };
        var result = JsonSerializer.Serialize(employee, options1);
        Console.WriteLine("Json: " + result);
    }

    [Fact]
    public void DateOnly_Test()
    {
        var date = new DateOnly(2022, 3, 8);

        var expect = "2022-03-08";

        var actual = date.ToString();
        actual.Should().Be(expect);
    }
}
using AutoMapper;
using DemoStaffManager.Business.DataTransferObjects.EmployeeDtos;
using DemoStaffManager.Domain.Core.DbEntities;

namespace DemoStaffManager.Business.DataTransferObjects.AutoMapperProfiles;

public class DefaultMapperProfile : Profile
{
    public DefaultMapperProfile()
    {
        CreateMap<Department, DepartmentOutDto>();
        CreateMap<CreateDepartmentDto, Department>();
        CreateMap<UpdateDepartmentDto, Department>();
        
        CreateMap<Employee, EmployeeShortOutDto>()
            .ForMember(dest => dest.Salary, 
            opt => 
                opt.MapFrom(src => src.GetActualSalary().Value))
            .ForMember(dest=> dest.Department,
                opt => opt.MapFrom(
                    src => src.GetActualDepartment().Department.Name));
    }
    
}
using AutoMapper;
using DemoStaffManager.Business.DataTransferObjects.EmployeeDtos;
using DemoStaffManager.Business.DataTransferObjects.EmploymentPeriodDtos;
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
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(
                    src => src.FullName()))
            .ForMember(dest => dest.BirthDay,
                opt => opt.MapFrom(
                    src => src.BirthDay.ToString("O")))
            .ForMember(dest => dest.Salary, 
            opt => 
                opt.MapFrom(src => src.GetActualSalarySafely()))
            .ForMember(dest=> dest.Department,
                opt => 
                opt.MapFrom(src => src.GetActualDepartmentNameSafely()))
            .ForMember(dest => dest.EmploymentStart,
                opt =>
                opt.MapFrom(src => src.GetStartEmploymentSafely()));
        
        
        
        CreateMap<EmploymentPeriod, EmploymentPeriodOutDto>()
            .ForMember(dest => dest.Start,
            opt => opt.MapFrom(
                src => src.Start.ToString("O")))
            .ForMember(dest => dest.End,
                opt => opt.MapFrom(
                    src => src.End.ToString("O")))
            .ForMember(dest => dest.DepartmentId,
                opt => opt.MapFrom(
                    src => src.Department.Id));

    }
    
}
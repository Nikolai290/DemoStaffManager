using AutoMapper;
using DemoStaffManager.Business.Abstracts.Services;
using DemoStaffManager.Business.DataTransferObjects.EmployeeDtos;
using DemoStaffManager.Business.DataTransferObjects.EmploymentPeriodDtos;
using DemoStaffManager.Domain.Abstracts.Repositories;
using DemoStaffManager.Domain.Core.DbEntities;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DemoStaffManager.Business.Implementation.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<EmployeeService> _logger;
    private readonly IValidator<CreateEmployeeDto> _createValidator;

    public EmployeeService(
        IEmployeeRepository employeeRepository,
        IDepartmentRepository departmentRepository,
        IMapper mapper,
        ILogger<EmployeeService> logger,
        IValidator<CreateEmployeeDto> createValidator)
    {
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
        _mapper = mapper;
        _logger = logger;
        _createValidator = createValidator;
    }
    
    public async Task<IEnumerable<EmployeeShortOutDto>> GetAllShortAsync(CancellationToken cancellationToken)
    {
        var resultQuery = _employeeRepository.GetAllAsync(cancellationToken);
        var resultDtos = _mapper.Map<IEnumerable<EmployeeShortOutDto>>(resultQuery);
        
        return resultDtos;
    }

    public async Task<EmployeeShortOutDto> CreateAsync(CreateEmployeeDto createDto, CancellationToken cancellationToken)
    {
        var validateResult = await _createValidator.ValidateAsync(createDto, cancellationToken);
        var newEntity = _mapper.Map<Employee>(createDto);
        var resultEntity = await _employeeRepository.CreateAsync(newEntity, cancellationToken);
        var resultDto = _mapper.Map<EmployeeShortOutDto>(resultEntity);
        
        return resultDto;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        await _employeeRepository.DeleteAsync(id, cancellationToken);
    }

    public async Task AddEmploymentPeriodAsync(CreateEmploymentPeriodDto createDto, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetAsync(createDto.EmployeeId, cancellationToken);
        var department = await _departmentRepository.GetAsync(createDto.DepartmentId, cancellationToken);
        var startDate = DateOnly.ParseExact(createDto.Start, "O");
        employee.AddEmploymentPeriod(startDate, department, createDto.Salary);
        await _employeeRepository.UpdateAsync(employee, cancellationToken);
    }

    public async Task DismissAsync(DismissEmploymentPeriodDto dismissDto, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetAsync(dismissDto.EmployeeId, cancellationToken);
        var endDate = DateOnly.ParseExact(dismissDto.End, "O");
        employee.Dismiss(endDate);
        await _employeeRepository.UpdateAsync(employee, cancellationToken);
    }
}
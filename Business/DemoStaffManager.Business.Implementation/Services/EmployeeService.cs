using AutoMapper;
using DemoStaffManager.Business.Abstracts.Services;
using DemoStaffManager.Business.DataTransferObjects.EmployeeDtos;
using DemoStaffManager.Domain.Abstracts.Repositories;
using DemoStaffManager.Domain.Core.DbEntities;
using Microsoft.Extensions.Logging;

namespace DemoStaffManager.Business.Implementation.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<EmployeeService> _logger;

    public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, ILogger<EmployeeService> logger)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
        _logger = logger;
    }
    
    public async Task<IEnumerable<EmployeeShortOutDto>> GetAllShortAsync(CancellationToken cancellationToken)
    {
        var resultQuery = _employeeRepository.GetAllAsync(cancellationToken);
        var resultDtos = _mapper.Map<IEnumerable<EmployeeShortOutDto>>(resultQuery);
        
        return resultDtos;
    }

    public async Task<EmployeeShortOutDto> CreateAsync(CreateEmployeeDto createDto, CancellationToken cancellationToken)
    {
        var newEntity = _mapper.Map<Employee>(createDto);
        var resultEntity = await _employeeRepository.CreateAsync(newEntity, cancellationToken);
        var resultDto = _mapper.Map<EmployeeShortOutDto>(resultEntity);
        
        return resultDto;
    }
    


    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        await _employeeRepository.DeleteAsync(id, cancellationToken);
    }
}
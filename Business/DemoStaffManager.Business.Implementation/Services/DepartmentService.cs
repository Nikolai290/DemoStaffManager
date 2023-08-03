using AutoMapper;
using DemoStaffManager.Business.Abstracts.Services;
using DemoStaffManager.Business.DataTransferObjects;
using DemoStaffManager.Domain.Abstracts.Repositories;
using DemoStaffManager.Domain.Core.DbEntities;
using Microsoft.Extensions.Logging;

namespace DemoStaffManager.Business.Implementation.Services;

public class DepartmentService : IDepartmentService
{
    private readonly ILogger<DepartmentService> _logger;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IMapper _mapper;

    public DepartmentService(ILogger<DepartmentService> logger,
        IDepartmentRepository departmentRepository,
        IMapper mapper)
    {
        _logger = logger;
        _departmentRepository = departmentRepository;
        _mapper = mapper;
    }
    
    
    public async Task<IEnumerable<DepartmentOutDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var queryResult = _departmentRepository.GetAllAsync(cancellationToken);

        var resultDtos = _mapper.Map<IEnumerable<DepartmentOutDto>>(queryResult);
        
        return resultDtos;
    }

    public async Task<DepartmentOutDto> CreateAsync(CreateDepartmentDto createDto, CancellationToken cancellationToken)
    {
        var newEntity = _mapper.Map<Department>(createDto);
        var resultEntity = await _departmentRepository.CreateAsync(newEntity, cancellationToken);
        var resultDto = _mapper.Map<DepartmentOutDto>(resultEntity);
        
        return resultDto;
    }

    public async Task<DepartmentOutDto> UpdateAsync(int id, UpdateDepartmentDto updateDto, CancellationToken cancellationToken)
    {
        var entity = await _departmentRepository.GetAsync(id, cancellationToken);
        _mapper.Map(updateDto, entity);
        var resultEntity = await _departmentRepository.UpdateAsync(entity, cancellationToken);
        var resultDto = _mapper.Map<DepartmentOutDto>(resultEntity);
        
        return resultDto;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        await _departmentRepository.DeleteAsync(id, cancellationToken);
    }
}
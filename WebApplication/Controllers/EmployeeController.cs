
using DemoStaffManager.Business.Abstracts.Services;
using DemoStaffManager.Business.DataTransferObjects.EmployeeDtos;
using DemoStaffManager.Business.DataTransferObjects.EmploymentPeriodDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    private readonly ILogger<EmployeeController> _logger;

    public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
    {
        _employeeService = employeeService;
        _logger = logger;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeShortOutDto>>> GetAllAsync(CancellationToken cancellationToken)
    {
        try
        {
            var result = await _employeeService.GetAllShortAsync(cancellationToken);
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<EmployeeShortOutDto>> CreateAsync([FromBody] CreateEmployeeDto createDto, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _employeeService.CreateAsync(createDto, cancellationToken);
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpPost("add-period")]
    public async Task<ActionResult> AddEmploymentPeriodAsync(CreateEmploymentPeriodDto createDto,
        CancellationToken cancellationToken)
    {
        try
        {
            await _employeeService.AddEmploymentPeriodAsync(createDto, cancellationToken);
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost("dismiss")]
    public async Task<ActionResult> DismissAsync(DismissEmploymentPeriodDto dismissDto,
        CancellationToken cancellationToken)
    {
        try
        {
            await _employeeService.DismissAsync(dismissDto, cancellationToken);
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        try
        {
            await _employeeService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return BadRequest(e);
        }
    }
}
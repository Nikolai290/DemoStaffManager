using DemoStaffManager.Business.Abstracts.Services;
using DemoStaffManager.Business.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class DepartmentController : ControllerBase
{
    private readonly ILogger<DepartmentController> _logger;
    private readonly IDepartmentService _departmentService;
    
    public DepartmentController(ILogger<DepartmentController> logger,
        IDepartmentService departmentService)
    {
        _logger = logger;
        _departmentService = departmentService;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<DepartmentOutDto>>> GetAllAsync(CancellationToken cancellationToken)
    {
        try
        {
            var result =  await _departmentService.GetAllAsync(cancellationToken);
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return BadRequest(e);
        }
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] CreateDepartmentDto createDto, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _departmentService.CreateAsync(createDto, cancellationToken);
            return Created("", result);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return BadRequest(e);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateDepartmentDto updateDto, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _departmentService.UpdateAsync(id, updateDto, cancellationToken);
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return BadRequest(e);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        try
        {
            await _departmentService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return BadRequest(e);
        }
    }
}
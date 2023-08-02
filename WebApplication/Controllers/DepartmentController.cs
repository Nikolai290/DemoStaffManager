using DemoStaffManager.Business.Abstracts.Services;
using DemoStaffManager.Business.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers;

public class DepartmentController : BaseController
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
    public async Task<ActionResult<IEnumerable<DepartmentOutDto>>> GetAllAsync([FromRoute] int skip,[FromRoute] int limit, CancellationToken cancellationToken)
    {
        try
        {
            var result =  await _departmentService.GetAllAsync(skip, limit, cancellationToken);
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
            await _departmentService.CreateAsync(createDto, cancellationToken);
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return BadRequest(e);
        }
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult> UpdateAsync([FromRoute] int Id, [FromBody] UpdateDepartmentDto updateDto, CancellationToken cancellationToken)
    {
        try
        {
            await _departmentService.UpdateAsync(Id, updateDto, cancellationToken);
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return BadRequest(e);
        }
    }
    
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] int Id, CancellationToken cancellationToken)
    {
        try
        {
            await _departmentService.DeleteAsync(Id, cancellationToken);
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return BadRequest(e);
        }
    }
}
using DemoStaffManager.Domain.Abstracts.Repositories;
using DemoStaffManager.Domain.Core.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DemoStaffManager.Domain.Implementation.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly MsSqlContext _msSqlContext;
    private readonly ILogger<DepartmentRepository> _logger;

    public DepartmentRepository(MsSqlContext msSqlContext,
        ILogger<DepartmentRepository> logger)
    {
        _msSqlContext = msSqlContext;
        _logger = logger;
    }
    
    public async Task<IEnumerable<Department>> GetListAsync(Predicate<Department> match = null, int skip = 0, int limit = 0)
    {
        return match == null ?
            _msSqlContext.Departments.Skip(skip).Take(limit) :
            _msSqlContext.Departments.Where(item => match(item)).Skip(skip).Take(limit);
    }

    public Task<Department> GetAsync(int id)
    {
        return _msSqlContext.Departments.SingleAsync(item => item.Id == id);
    }

    public Department CreateAsync(Department obj)
    {
        return _msSqlContext.Departments.AddAsync(obj).Result.Entity;
    }

    public Task CreateRangeAsync(IEnumerable<Department> list)
    {
        var result = _msSqlContext.Departments.AddRangeAsync(list);
        return result;
    }

    public Department Update(Department obj)
    {
        var result = _msSqlContext.Departments.Update(obj).Entity;
        return result;
    }

    public async Task DeleteAsync(int id)
    {
        var obj = await GetAsync(id);
        _msSqlContext.Departments.Remove(obj);
        _msSqlContext.Departments.ExecuteDeleteAsync();

    }

    public async Task DeleteByAsync(Predicate<Department> match)
    {
        var forDelete = await GetListAsync(match);
        _msSqlContext.Departments.RemoveRange(forDelete);
        _msSqlContext.Departments.ExecuteDeleteAsync();
    }
}
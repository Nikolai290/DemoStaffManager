using DemoStaffManager.Domain.Abstracts.Repositories;
using DemoStaffManager.Domain.Core.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DemoStaffManager.Domain.Implementation.Repositories;

public class DepartmentRepository : BaseRepository, IDepartmentRepository, IBaseRepository
{
    private readonly ILogger<DepartmentRepository> _logger;

    public DepartmentRepository(MsSqlContext msSqlContext,
        ILogger<DepartmentRepository> logger) : base(msSqlContext, logger)
    {
    }
    
    public async Task<IEnumerable<Department>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = _msSqlContext.Departments;

        return result;
    }

    public Task<Department> GetAsync(int id, CancellationToken cancellationToken)
    {
        return _msSqlContext.Departments.SingleAsync(item => item.Id == id, cancellationToken);
    }

    public async Task<Department> CreateAsync(Department obj, CancellationToken cancellationToken)
    {
        var result = await _msSqlContext.Departments.AddAsync(obj, cancellationToken);
        await SaveAsync(cancellationToken);
        return result.Entity;
    }

    public async Task CreateRangeAsync(IEnumerable<Department> list, CancellationToken cancellationToken)
    {
        await _msSqlContext.Departments.AddRangeAsync(list, cancellationToken);
        await SaveAsync(cancellationToken);
    }

    public async Task<Department> UpdateAsync(Department obj, CancellationToken cancellationToken)
    {
        var result = _msSqlContext.Departments.Update(obj).Entity;
        await SaveAsync(cancellationToken);
        return result;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var obj = await GetAsync(id, cancellationToken);
        _msSqlContext.Departments.Remove(obj);
        await SaveAsync(cancellationToken);
    }
}
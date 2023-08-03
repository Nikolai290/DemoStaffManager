using DemoStaffManager.Domain.Abstracts.Repositories;
using DemoStaffManager.Domain.Core.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DemoStaffManager.Domain.Implementation.Repositories;

public abstract class BaseCrudRepository<TEntity> : IBaseCrudRepository<TEntity> where TEntity : BaseDbEntity
{
    protected readonly MsSqlContext _msSqlContext;
    protected readonly ILogger<BaseCrudRepository<TEntity>> _logger;

    protected BaseCrudRepository(MsSqlContext msSqlContext,
        ILogger<BaseCrudRepository<TEntity>> logger)
    {
        _msSqlContext = msSqlContext;
        _logger = logger;
    }

    public IQueryable<TEntity> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = _msSqlContext.Set<TEntity>();
        return result;
    }

    public Task<TEntity> GetAsync(int id, CancellationToken cancellationToken)
    {
        return _msSqlContext.Set<TEntity>().SingleAsync(item => item.Id == id, cancellationToken);
    }

    public async Task<TEntity> CreateAsync(TEntity obj, CancellationToken cancellationToken)
    {
        var result = await _msSqlContext.Set<TEntity>().AddAsync(obj, cancellationToken);
        await SaveAsync(cancellationToken);
        return result.Entity;
    }

    public async Task CreateRangeAsync(IEnumerable<TEntity> list, CancellationToken cancellationToken)
    {
        await _msSqlContext.Set<TEntity>().AddRangeAsync(list, cancellationToken);
        await SaveAsync(cancellationToken);
    }

    public async Task<TEntity> UpdateAsync(TEntity obj, CancellationToken cancellationToken)
    {
        var result = _msSqlContext.Set<TEntity>().Update(obj).Entity;
        await SaveAsync(cancellationToken);
        return result;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var obj = await GetAsync(id, cancellationToken);
        _msSqlContext.Set<TEntity>().Remove(obj);
        await SaveAsync(cancellationToken);
    }

    public Task SaveAsync(CancellationToken cancellationToken)
    {
        return _msSqlContext.SaveChangesAsync(cancellationToken);
    }
}
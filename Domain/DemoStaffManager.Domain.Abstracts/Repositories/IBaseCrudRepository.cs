using DemoStaffManager.Domain.Core.DbEntities;

namespace DemoStaffManager.Domain.Abstracts.Repositories;

public interface IBaseCrudRepository<TEntity>  where TEntity : BaseDbEntity
{
    Task<IEnumerable<TEntity>> GetListAsync(Action<TEntity, bool> match = null, int skip = 0, int limit = 0);

    Task<TEntity> GetAsync(int Id);

    Task<TEntity> GetByAsync(Action<TEntity, bool> match);

    Task<TEntity> CreateAsync(TEntity obj);

    Task<IEnumerable<TEntity>> CreateRangeAsync(IEnumerable<TEntity> list);
    
    Task<TEntity> UpdateAsync(TEntity obj);

    Task<int> DeleteAsync(int Id);
    
    Task<int> DeleteByAsync(Action<TEntity, bool> match);
}
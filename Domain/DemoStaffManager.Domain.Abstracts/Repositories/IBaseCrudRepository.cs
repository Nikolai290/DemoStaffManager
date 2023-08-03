using DemoStaffManager.Domain.Core.DbEntities;

namespace DemoStaffManager.Domain.Abstracts.Repositories;

public interface IBaseCrudRepository<TEntity>  where TEntity : IEntity
{
    IQueryable<TEntity> GetAllAsync(CancellationToken cancellationToken);
    
    Task<TEntity> GetAsync(int id, CancellationToken cancellationToken);
    
    Task<TEntity> CreateAsync(TEntity obj, CancellationToken cancellationToken);
    
    Task CreateRangeAsync(IEnumerable<TEntity> list, CancellationToken cancellationToken);
    
    Task<TEntity> UpdateAsync(TEntity obj, CancellationToken cancellationToken);
    
    Task DeleteAsync(int id, CancellationToken cancellationToken);
    
    Task SaveAsync(CancellationToken cancellationToken);

}

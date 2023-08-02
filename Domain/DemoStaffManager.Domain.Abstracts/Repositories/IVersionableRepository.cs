using DemoStaffManager.Domain.Core.DbEntities;

namespace DemoStaffManager.Domain.Abstracts.Repositories;

public interface IVersionableRepository<TEntity> where TEntity : IEntity, IVersionableByDateOnly
{
    Task<IEnumerable<TEntity>> GetActualListAsync(Action<TEntity, bool> match = null, int skip = 0, int limit = 0);

    Task<TEntity> GetActualAsync(int Id);
}
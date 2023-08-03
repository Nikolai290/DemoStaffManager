using DemoStaffManager.Domain.Core.DbEntities;

namespace DemoStaffManager.Domain.Abstracts.Repositories;

public interface IDepartmentRepository
{
    Task<IEnumerable<Department>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Department> GetAsync(int id, CancellationToken cancellationToken);

    Task<Department>  CreateAsync(Department obj, CancellationToken cancellationToken);

    Task CreateRangeAsync(IEnumerable<Department> list, CancellationToken cancellationToken);
    
    Task<Department> UpdateAsync(Department obj, CancellationToken cancellationToken);

    Task DeleteAsync(int id, CancellationToken cancellationToken);
}
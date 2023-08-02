using DemoStaffManager.Domain.Core.DbEntities;

namespace DemoStaffManager.Domain.Abstracts.Repositories;

public interface IDepartmentRepository
{
    Task<IEnumerable<Department>> GetListAsync(Predicate<Department> match = null, int skip = 0, int limit = 0);

    Task<Department> GetAsync(int id);

    Department CreateAsync(Department obj);

    Task CreateRangeAsync(IEnumerable<Department> list);
    
    Department Update(Department obj);

    Task DeleteAsync(int id);
    
    Task DeleteByAsync(Predicate<Department> match);
}
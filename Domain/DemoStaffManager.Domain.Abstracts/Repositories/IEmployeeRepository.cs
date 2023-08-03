using DemoStaffManager.Domain.Core.DbEntities;

namespace DemoStaffManager.Domain.Abstracts.Repositories;

public interface IEmployeeRepository : IBaseCrudRepository<Employee>
{

}
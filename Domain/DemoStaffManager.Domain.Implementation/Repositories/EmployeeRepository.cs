using DemoStaffManager.Domain.Abstracts.Repositories;
using DemoStaffManager.Domain.Core.DbEntities;
using Microsoft.Extensions.Logging;

namespace DemoStaffManager.Domain.Implementation.Repositories;

public class EmployeeRepository : BaseCrudRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(MsSqlContext msSqlContext,
        ILogger<EmployeeRepository> logger) : base(msSqlContext, logger)
    {
    }
}
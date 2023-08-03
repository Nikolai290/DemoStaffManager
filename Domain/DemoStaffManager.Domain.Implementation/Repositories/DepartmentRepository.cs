using DemoStaffManager.Domain.Abstracts.Repositories;
using DemoStaffManager.Domain.Core.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DemoStaffManager.Domain.Implementation.Repositories;

public class DepartmentRepository : BaseCrudRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(MsSqlContext msSqlContext,
        ILogger<DepartmentRepository> logger) : base(msSqlContext, logger)
    {
    }
}
using DemoStaffManager.Domain.Abstracts.Repositories;
using Microsoft.Extensions.Logging;

namespace DemoStaffManager.Domain.Implementation.Repositories;

public abstract class BaseRepository : IBaseRepository
{
    protected readonly MsSqlContext _msSqlContext;
    private readonly ILogger<DepartmentRepository> _logger;

    protected BaseRepository(MsSqlContext msSqlContext,
        ILogger<DepartmentRepository> logger)
    {
        _msSqlContext = msSqlContext;
        _logger = logger;
    }

    public Task SaveAsync(CancellationToken cancellationToken)
    {
        return _msSqlContext.SaveChangesAsync(cancellationToken);
    }
}
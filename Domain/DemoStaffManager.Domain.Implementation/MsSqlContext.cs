using DemoStaffManager.Domain.Core.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace DemoStaffManager.Domain.Implementation;

public class MsSqlContext : DbContext
{
    private readonly string _connectionString;
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmploymentPeriod> EmploymentPeriods { get; set; }
    
    public MsSqlContext(string connectionString)
    {
        _connectionString = connectionString;

        Database.EnsureCreated();
    }

    public MsSqlContext(DbContextOptions<MsSqlContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>().HasAlternateKey(d => d.Name);
        modelBuilder.Entity<EmploymentPeriod>().HasAlternateKey(p => p.PreviousId);
    }
}
namespace DemoStaffManager.Domain.Core.DbEntities;

public abstract record BaseDbEntity : IEntity
{
    public int Id { get; init; }
}

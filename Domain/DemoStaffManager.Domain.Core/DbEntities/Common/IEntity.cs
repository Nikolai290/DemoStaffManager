namespace DemoStaffManager.Domain.Core.DbEntities;

public interface IEntity : IEntity<int>
{
    int Id { get; }
}

public interface IEntity<TId>
{
    TId Id { get; }
}
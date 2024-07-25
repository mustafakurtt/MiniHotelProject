namespace Core.Entities;

public interface IEntity<T> : IEntityTimestamps
{
    public T Id { get; set; }
}
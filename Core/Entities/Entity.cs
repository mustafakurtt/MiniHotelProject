namespace Core.Entities;

public class Entity<T> : IEntity<T>
{
    public T Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }


    public Entity()
    {
        
    }

    public Entity(T id): this()
    {
        Id = id;
    }
}
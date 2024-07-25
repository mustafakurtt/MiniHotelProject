using System.Text.Json.Serialization;

namespace Core.Entities;

public class Entity<T> : IEntity<T>
{
    [JsonIgnore]
    public T Id { get; set; }
    [JsonIgnore]
    public DateTime CreatedDate { get; set; }
    [JsonIgnore]
    public DateTime? UpdatedDate { get; set; }
    [JsonIgnore]
    public DateTime? DeletedDate { get; set; }


    public Entity()
    {
        
    }

    public Entity(T id): this()
    {
        Id = id;
    }
}
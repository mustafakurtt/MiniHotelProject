using System.Text.Json.Serialization;
using Core.Entities;

namespace Entities.Concrete;

public class RoomType : Entity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public short MaxGuestCount { get; set; }
    public string ImageUrl { get; set; }
    [JsonIgnore]
    public virtual ICollection<Room> Rooms { get; set; }
}
using Core.Entities;

namespace Entities.Concrete;

public class RoomType : Entity<Guid>
{
    public string Description { get; set; }
    public short MaxGuestCount { get; set; }
    public string ImageUrl { get; set; }
    public virtual ICollection<Room> Rooms { get; set; }
}
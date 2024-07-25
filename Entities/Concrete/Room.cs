using Core.Entities;
using Entities.Concrete.Enums;

namespace Entities.Concrete;

public class Room : Entity<Guid>
{
    public Guid RoomTypeId { get; set; }
    public string RoomNumber { get; set; }
    public RoomStatus RoomStatus { get; set; }
}
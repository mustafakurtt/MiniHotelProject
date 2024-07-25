using Entities.Abstract;

namespace Entities.Concrete;

public class Room : IEntity
{
   
    public Guid Id { get; set; }
    public Guid RoomTypeId { get; set; }
    public string RoomNumber { get; set; }
    public RoomStatus RoomStatus { get; set; }

}
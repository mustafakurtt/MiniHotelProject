using Entities.Concrete.Enums;

namespace Entities.DTOs.RoomDTOs;

public class RoomAddRequestDto
{
    public Guid RoomTypeId { get; set; }
    public string RoomNumber { get; set; }
    public RoomStatus RoomStatus { get; set; }
}
using Entities.Concrete.Enums;

namespace Entities.DTOs.RoomDTOs;

public class RoomUpdateRequestDto
{
    public Guid Id { get; set; }
    public Guid RoomTypeId { get; set; }
    public string RoomNumber { get; set; }
    public RoomStatus RoomStatus { get; set; }
}
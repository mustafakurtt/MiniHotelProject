using Entities.Concrete;
using Entities.Concrete.Enums;
using Entities.DTOs.RoomTypeDTOs;

namespace Entities.DTOs.RoomDTOs;

public class RoomResponseDto
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string RoomNumber { get; set; }
    public RoomStatus RoomStatus { get; set; }
    public RoomTypeResponseDto RoomType { get; set; }
}
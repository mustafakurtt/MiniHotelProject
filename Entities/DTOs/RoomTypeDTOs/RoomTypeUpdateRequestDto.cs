namespace Entities.DTOs.RoomTypeDTOs;

public class RoomTypeUpdateRequestDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public short MaxGuestCount { get; set; }
    public string ImageUrl { get; set; }
}
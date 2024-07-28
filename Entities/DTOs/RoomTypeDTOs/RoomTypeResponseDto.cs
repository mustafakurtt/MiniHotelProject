namespace Entities.DTOs.RoomTypeDTOs;

public class RoomTypeResponseDto
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public short MaxGuestCount { get; set; }
    public string ImageUrl { get; set; }
}
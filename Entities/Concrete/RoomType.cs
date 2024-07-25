using Entities.Abstract;

namespace Entities.Concrete;

public class RoomType : IEntity
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public short MaxGuestCount { get; set; }
    public string ImageUrl { get; set; }
}
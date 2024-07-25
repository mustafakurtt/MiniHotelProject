using Entities.Concrete;

namespace Business.Abstract;

public interface IRoomTypeService
{
    List<RoomType> GetAll();
    RoomType GetById(Guid id);
    void Add(RoomType roomType);
    void Update(RoomType roomType);
    void Delete(RoomType roomType);
}
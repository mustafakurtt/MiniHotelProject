using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IRoomTypeDal
{
    List<RoomType> GetAll();
    RoomType GetById(Guid id);
    void Add(RoomType roomType);
    void Delete (RoomType roomType);
    void Update (RoomType roomType);

}
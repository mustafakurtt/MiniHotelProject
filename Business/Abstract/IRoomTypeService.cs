using Entities.Concrete;

namespace Business.Abstract;

public interface IRoomTypeService
{
    Task<List<RoomType>> GetAll();
    Task<RoomType?> GetById(Guid id);
    Task<RoomType> Add(RoomType roomType);
    Task<RoomType> Update(RoomType roomType);
    Task<RoomType> Delete(RoomType roomType);
}
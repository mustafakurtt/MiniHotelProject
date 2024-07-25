using Business.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;

namespace Business.Concrete;

public class RoomTypeManager : IRoomTypeService
{
    private RoomTypeDal _roomTypeDal;

    public RoomTypeManager(RoomTypeDal roomTypeDal)
    {
        _roomTypeDal = roomTypeDal;
    }

    public List<RoomType> GetAll()
    {
        return _roomTypeDal.GetAll();
    }

    public RoomType GetById(Guid id)
    {
        return _roomTypeDal.GetById(id);
    }

    public void Add(RoomType roomType)
    {
        _roomTypeDal.Add(roomType);
    }

    public void Update(RoomType roomType)
    {
        _roomTypeDal.Update(roomType);
    }

    public void Delete(RoomType roomType)
    {
        _roomTypeDal.Delete(roomType);
    }
}
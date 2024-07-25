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

    public async Task<List<RoomType>> GetAll()
    {
        return await _roomTypeDal.GetListAsync();
    }

    public async Task<RoomType?> GetById(Guid id)
    {
        return await _roomTypeDal.GetAsync(r => r.Id == id);
    }

    public async Task<RoomType> Add(RoomType roomType)
    {
        return await _roomTypeDal.AddAsync(roomType);
    }

    public async Task<RoomType> Update(RoomType roomType)
    {
       return await _roomTypeDal.UpdateAsync(roomType);
    }

    public async Task<RoomType> Delete(RoomType roomType)
    {
        return await _roomTypeDal.DeleteAsync(roomType);
    }
}
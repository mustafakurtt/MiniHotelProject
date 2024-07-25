using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;

public class RoomManager : IRoomService
{
    private readonly IRoomDal _roomDal;

    public RoomManager(IRoomDal roomDal)
    {
        _roomDal = roomDal;
    }

    public async Task<IDataResult<List<Room>>> GetAllAsync()
    {
        var response = await _roomDal.GetListAsync();
        return new SuccessDataResult<List<Room>>(response);
    }

    public async Task<IDataResult<Room>> GetByIdAsync(Guid id)
    {
        Room? room = await _roomDal.GetAsync(r => r.Id == id);
        if (room != null)
            return new SuccessDataResult<Room>(room);
        return new ErrorDataResult<Room>(RoomMessages.RoomNotExists);
    }

    public async Task<IResult> AddAsync(Room room)
    {
        Room? _room = await _roomDal.AddAsync(room);
        if (room != null)
            return new SuccessResult(RoomMessages.RoomAdded);
        return new ErrorResult();

    }

    public async Task<IResult> UpdateAsync(Room room)
    {
        Room? _room = await _roomDal.UpdateAsync(room);
        if (_room != null)
            return new SuccessResult(RoomMessages.RoomUpdated);
        return new ErrorResult(RoomMessages.RoomNotExists);
    }

    public async Task<IResult> DeleteAsync(Room room)
    {
        Room? _room = await _roomDal.DeleteAsync(room,false);
        if (_room != null)
            return new SuccessResult(RoomMessages.RoomDeleted);
        return new ErrorResult(RoomMessages.RoomNotExists);
    }

    public async Task<IDataResult<Room>> GetRoomDetails(Guid id)
    {
        var room= await _roomDal.GetAsync(
            predicate: r => r.Id == id,
            include: r => r.Include(rt => rt.RoomType)
        );

        if (room != null)
            return new SuccessDataResult<Room>(room);
        return new ErrorDataResult<Room>(RoomMessages.RoomNotExists);
    }
}
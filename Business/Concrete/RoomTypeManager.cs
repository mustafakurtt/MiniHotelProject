using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;

namespace Business.Concrete;

public class RoomTypeManager : IRoomTypeService
{
    private readonly IRoomTypeDal _roomTypeDal;

    public RoomTypeManager(IRoomTypeDal roomTypeDal)
    {
        _roomTypeDal = roomTypeDal;
    }

    public async Task<IDataResult<List<RoomType>>> GetAllAsync()
    {
        var roomTypeList = await _roomTypeDal.GetListAsync();
        return new SuccessDataResult<List<RoomType>>(roomTypeList);
    }

    public async Task<IDataResult<RoomType>> GetByIdAsync(Guid id)
    {
        var roomType = await _roomTypeDal.GetAsync(r => r.Id == id);
        if (roomType != null)
            return new SuccessDataResult<RoomType>(roomType);
        return new ErrorDataResult<RoomType>(RoomTypeMessages.RoomTypeNotExists);

    }
    [ValidationAspect(typeof(RoomTypeValidator))]
    public async Task<IResult> AddAsync(RoomType roomType)
    {
        var _roomType = await _roomTypeDal.AddAsync(roomType);
        if (_roomType != null)
            return new SuccessResult(RoomTypeMessages.RoomTypeAdded);
        return new ErrorDataResult<RoomType>(RoomTypeMessages.RoomTypeNotExists);
    }

    public async Task<IResult> UpdateAsync(RoomType roomType)
    {
       var _roomType = await _roomTypeDal.UpdateAsync(roomType);
       if (roomType != null)
           return new SuccessResult(RoomTypeMessages.RoomTypeUpdated);
       return new ErrorResult(RoomTypeMessages.RoomTypeNotExists);
    }

    public async Task<IResult> DeleteAsync(RoomType roomType)
    {
        var _roomType = await _roomTypeDal.DeleteAsync(roomType);
        if (roomType != null)
            return new SuccessResult(RoomTypeMessages.RoomTypeDeleted);
        return new ErrorResult(RoomTypeMessages.RoomTypeNotExists);
    }
}
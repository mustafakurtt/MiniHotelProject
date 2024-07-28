using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.BusinessRules;

public class RoomTypeBusinessRules(IRoomTypeDal roomTypeDal)
{
    private readonly IRoomTypeDal _roomTypeDal = roomTypeDal;

    public async Task<IResult?> CheckIfRoomTypeNameExists(string roomTypeName)
    {
        var response = await _roomTypeDal.AnyAsync(rt => rt.Name == roomTypeName);
        if (response) return new ErrorResult(RoomTypeMessages.RoomTypeNameExists);
        return null;
    }
}
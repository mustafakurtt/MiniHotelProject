using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.RoomDTOs;


namespace Business.Abstract;

public interface IRoomService
{
    Task<IDataResult<List<RoomResponseDto>>> GetAllAsync();
    Task<IDataResult<RoomResponseDto>> GetByIdAsync(Guid id);
    Task<IResult> AddAsync (RoomAddRequestDto room);
    Task<IResult> UpdateAsync (RoomUpdateRequestDto room);
    Task<IResult> DeleteAsync (Guid id);  
    Task<IDataResult<Room>> GetRoomDetails(Guid id);
}
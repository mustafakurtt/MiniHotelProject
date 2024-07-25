using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface IRoomService
{
    Task<IDataResult<List<Room>>> GetAllAsync();
    Task<IDataResult<Room>> GetByIdAsync(Guid id);
    Task<IResult> AddAsync (Room room);
    Task<IResult> UpdateAsync (Room room);
    Task<IResult> DeleteAsync (Room room);  
    Task<IDataResult<Room>> GetRoomDetails(Guid id);


}
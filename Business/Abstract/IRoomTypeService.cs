using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface IRoomTypeService
{
    Task<IDataResult<List<RoomType>>> GetAllAsync();
    Task<IDataResult<RoomType>> GetByIdAsync(Guid id);
    Task<IResult> AddAsync(RoomType roomType);
    Task<IResult> UpdateAsync(RoomType roomType);
    Task<IResult> DeleteAsync(RoomType roomType);
    
}
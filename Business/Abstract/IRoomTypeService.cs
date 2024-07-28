using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.RoomTypeDTOs;

namespace Business.Abstract;

public interface IRoomTypeService
{
    Task<IDataResult<List<RoomTypeResponseDto>>> GetAllAsync();
    Task<IDataResult<RoomTypeResponseDto>> GetByIdAsync(Guid id);
    Task<IResult> AddAsync(RoomTypeAddRequestDto roomTypeAddRequestDto);
    Task<IResult> UpdateAsync(RoomTypeUpdateRequestDto roomTypeUpdateRequestDto);
    Task<IResult> DeleteAsync(Guid id);
    Task<IResult> AnyAsync(Guid id);
}
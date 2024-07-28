using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;
using Entities.DTOs.RoomDTOs;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;

public class RoomManager : IRoomService
{
    private readonly IRoomDal _roomDal;
    private readonly IMapper _mapper;
    private readonly IRoomTypeService _roomTypeService;

    public RoomManager(IRoomDal roomDal, IMapper mapper, IRoomTypeService roomTypeService)
    {
        _roomDal = roomDal;
        _mapper = mapper;
        _roomTypeService = roomTypeService;

    }
    [SecuredOperation("Admin")]
    public async Task<IDataResult<List<RoomResponseDto>>> GetAllAsync()
    {
        var roomList = await _roomDal.GetListAsync(
            include: r => r.Include(r => r.RoomType),
            orderBy: r => r.OrderBy(r => r.RoomNumber)
        );
        var mappedRoomList = _mapper.Map<List<RoomResponseDto>>(roomList);
        return new SuccessDataResult<List<RoomResponseDto>>(mappedRoomList);
    }
    [SecuredOperation("Admin")]
    public async Task<IDataResult<RoomResponseDto>> GetByIdAsync(Guid id)
    {
        var room = await _roomDal.GetAsync(
            predicate: r => r.Id == id,
            include: r => r.Include(r => r.RoomType)
        );
        if (room == null)
            return new ErrorDataResult<RoomResponseDto>(RoomMessages.RoomNotExists);
        
        var mappedRoom = _mapper.Map<RoomResponseDto>(room);
        return new SuccessDataResult<RoomResponseDto>(mappedRoom);
    }
    [SecuredOperation("Admin")]
    public async Task<IResult> AddAsync(RoomAddRequestDto roomAddRequestDto)
    {
        var roomTypeResponse = await _roomTypeService.AnyAsync(roomAddRequestDto.RoomTypeId);
        if (!roomTypeResponse.Success) return roomTypeResponse;

        var room = _mapper.Map<Room>(roomAddRequestDto);
        await _roomDal.AddAsync(room);
        return new SuccessResult(RoomMessages.RoomAdded);
    }
    [SecuredOperation("Admin")]
    public async Task<IResult> UpdateAsync(RoomUpdateRequestDto roomUpdateRequestDto)
    {
        var roomTypeResponse = await _roomTypeService.AnyAsync(roomUpdateRequestDto.RoomTypeId);
        if (!roomTypeResponse.Success) return roomTypeResponse;

        var existingRoom = await _roomDal.GetAsync(
            r => r.Id == roomUpdateRequestDto.Id
            );

        if (existingRoom == null)
            return new ErrorResult(RoomMessages.RoomNotExists);
        
        var updatedRoom = _mapper.Map(roomUpdateRequestDto, existingRoom);
        await _roomDal.UpdateAsync(updatedRoom);
        return new SuccessResult(RoomMessages.RoomUpdated);
    }
    [SecuredOperation("Admin")]
    public async Task<IResult> DeleteAsync(Guid id)
    {
        var room = await _roomDal.GetAsync(r => r.Id == id);
        if (room == null)
            return new ErrorResult(RoomMessages.RoomNotExists);
        
        await _roomDal.DeleteAsync(room, true);
        return new SuccessResult(RoomMessages.RoomDeleted);
    }
    [SecuredOperation("Admin")]
    public async Task<IDataResult<Room>> GetRoomDetails(Guid id)
    {
        var room = await _roomDal.GetAsync(
            predicate: r => r.Id == id,
            include: r => r.Include(r => r.RoomType).Include(r => r.Reservations)
        );
        if (room == null)
            return new ErrorDataResult<Room>(RoomMessages.RoomNotExists);
        
        return new SuccessDataResult<Room>(room);
    }
}
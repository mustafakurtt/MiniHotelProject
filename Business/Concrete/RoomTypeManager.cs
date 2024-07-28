using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.BusinessRules;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Business.ValidationRules.FluentValidation.RoomTypeValidators;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Core.Utilities.Business;
using Entities.DTOs.RoomTypeDTOs;

namespace Business.Concrete;

public class RoomTypeManager : IRoomTypeService
{
    private readonly IRoomTypeDal _roomTypeDal;
    private readonly RoomTypeBusinessRules _roomTypeBusinessRules;
    private readonly IMapper _mapper;

    public RoomTypeManager(IRoomTypeDal roomTypeDal, RoomTypeBusinessRules roomTypeBusinessRules, IMapper mapper)
    {
        _roomTypeDal = roomTypeDal;
        _roomTypeBusinessRules = roomTypeBusinessRules;
        _mapper = mapper;
    }

    [CacheAspect]
    public async Task<IDataResult<List<RoomTypeResponseDto>>> GetAllAsync()
    {
        var response =await _roomTypeDal.GetListAsync();
        var mappedResponse = _mapper.Map<List<RoomTypeResponseDto>>(response);
        return new SuccessDataResult<List<RoomTypeResponseDto>>(mappedResponse);
    }

    [SecuredOperation("Admin")]
    [CacheAspect]
    public async Task<IDataResult<RoomTypeResponseDto>> GetByIdAsync(Guid id)
    {
        var response = await _roomTypeDal.GetAsync(r => r.Id == id);
        if (response == null) return new ErrorDataResult<RoomTypeResponseDto>(RoomTypeMessages.RoomTypeNotExists);

        var mappedResponse = _mapper.Map<RoomTypeResponseDto>(response);
        return new SuccessDataResult<RoomTypeResponseDto>(mappedResponse);
    }

    [SecuredOperation("Admin")]
    [ValidationAspect(typeof(RoomTypeAddValidator))]
    [CacheRemoveAspect("IRoomTypeService.Get")]
    public async Task<IResult> AddAsync(RoomTypeAddRequestDto roomTypeAddRequestDto)
    {
        var roomType = _mapper.Map<RoomType>(roomTypeAddRequestDto);
        await _roomTypeDal.AddAsync(roomType);
        return new SuccessResult(RoomTypeMessages.RoomTypeAdded);
    }

    [SecuredOperation("Admin")]
    [ValidationAspect(typeof(RoomTypeUpdateValidator))]
    [CacheRemoveAspect("IRoomTypeService.Get")]
    public async Task<IResult> UpdateAsync(RoomTypeUpdateRequestDto roomTypeUpdateRequestDto)
    {
        var roomType = await _roomTypeDal.GetAsync(r => r.Id == roomTypeUpdateRequestDto.Id);
        if (roomType == null) return new ErrorResult(RoomTypeMessages.RoomTypeNotExists);
        roomType = _mapper.Map(roomTypeUpdateRequestDto, roomType);
        await _roomTypeDal.UpdateAsync(roomType);
        return new SuccessResult(RoomTypeMessages.RoomTypeUpdated);
    }

    [SecuredOperation("Admin")]
    [CacheRemoveAspect("IRoomTypeService.Get")]
    public async Task<IResult> DeleteAsync(Guid id)
    {
        var response = await _roomTypeDal.GetAsync(r => r.Id == id);
        if (response == null) return new ErrorResult(RoomTypeMessages.RoomTypeNotExists);

        await _roomTypeDal.DeleteAsync(response,true);
        return new SuccessResult(RoomTypeMessages.RoomTypeDeleted);
    }

    public async Task<IResult> AnyAsync(Guid id)
    {
        var response = await _roomTypeDal.AnyAsync(
            predicate: r => r.Id == id
        );
        if (response) return new SuccessResult();
        return new ErrorResult(RoomTypeMessages.RoomTypeNotExists);
    }
}
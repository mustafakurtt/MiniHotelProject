using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.RoomTypeDTOs;


namespace Business.Profiles;

public class RoomTypeProfile : Profile
{
    public RoomTypeProfile()
    {
        CreateMap<RoomType, RoomTypeAddRequestDto>().ReverseMap();
        CreateMap<RoomType, RoomTypeUpdateRequestDto>().ReverseMap();
        CreateMap<RoomType, RoomTypeResponseDto>().ReverseMap();
    }
}
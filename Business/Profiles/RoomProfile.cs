using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.RoomDTOs;

namespace Business.Profiles;

public class RoomProfile : Profile
{
    public RoomProfile()
    {
        // Room -> RoomResponseDto
        CreateMap<Room, RoomResponseDto>()
            .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.RoomType));

        // RoomAddRequestDto -> Room
        CreateMap<RoomAddRequestDto, Room>().ReverseMap();

        // RoomUpdateRequestDto -> Room
        CreateMap<RoomUpdateRequestDto, Room>().ReverseMap();
    }
}
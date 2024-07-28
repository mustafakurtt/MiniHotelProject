using AutoMapper;
using Core.Entities.Concrete;
using DataAccess.Concrete;

namespace Business.Profiles;

public class ModerationProfile: Profile
{
    public ModerationProfile()
    {
        //CreateMap<OperationClaim, ClaimDto>().ReverseMap();

        //CreateMap<GetAllUsersResponseDto, User>().ReverseMap();
        //CreateMap<User, GetAllUsersResponseDto>()
        //    .ForMember(dest => dest.OperationClaims, opt => opt.MapFrom(src => src.UserOperationClaims.Select(uoc => uoc.OperationClaim)))
        //    .ReverseMap();

        //CreateMap<User, GetUserResponseDto>().ReverseMap();
        //CreateMap<User, GetUserResponseDto>()
        //    .ForMember(dest => dest.OperationClaims, opt => opt.MapFrom(src => src.UserOperationClaims.Select(uoc => uoc.OperationClaim)))
        //    .ReverseMap();

        //CreateMap<User, AddUserRequestDto>();
        //CreateMap<User, AddUserResponseDto>();

        //CreateMap<User, UpdateUserRequestDto>();
        //CreateMap<User, UpdateUserResponseDto>();

        //CreateMap<User, DeleteUserResponseDto>();

        //CreateMap<User, RemoveBanUserResponseDto>();

        //CreateMap<UserOperationClaim, RemoveClaimUserResponseDto>();
    }
}
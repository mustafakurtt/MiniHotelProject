using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs.AuthDTOs;

namespace Business.Abstract;

public interface IAuthService
{
    Task<IDataResult<User>> LoginAsync(UserForLoginDto userForLoginDto);
    Task<IDataResult<AccessToken>> CreateAccessToken(User user);
}
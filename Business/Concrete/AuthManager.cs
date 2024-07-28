using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs.AuthDTOs;
using System.Security.Claims;

namespace Business.Concrete;

public class AuthManager : IAuthService
{
    private IUserService _userService;
    private ITokenHelper _tokenHelper;

    public AuthManager(IUserService userService, ITokenHelper tokenHelper)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
    }

    public async Task<IDataResult<User>> LoginAsync(UserForLoginDto userForLoginDto)
    {
        var userDataResponse = await _userService.GetByUserCodeAsync(userForLoginDto.UserCode);
        if (!userDataResponse.Success) return userDataResponse;

        var user = userDataResponse.Data;

        if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt)) 
            return new ErrorDataResult<User>(AuthMessages.PasswordInCorrect);
        return new SuccessDataResult<User>(user, AuthMessages.LoginSuccessful);
    }

    public async Task<IDataResult<AccessToken>> CreateAccessToken(User user)
    {
        var claimsDataResult = _userService.GetClaims(user);
        if (!claimsDataResult.Success) return new ErrorDataResult<AccessToken>();
        var claims = claimsDataResult.Data;
        var accessToken = _tokenHelper.CreateToken(user, claims);
        return new SuccessDataResult<AccessToken>(accessToken, AuthMessages.TokenCreated);


    }
}
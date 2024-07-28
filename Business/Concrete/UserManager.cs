using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;

namespace Business.Concrete;

public class UserManager : IUserService
{
    private readonly IUserDal _userDal;
    private readonly IMapper _mapper;

    public UserManager(IUserDal userDal, IMapper mapper)
    {
        _userDal = userDal;
        _mapper = mapper;
    }

    public async Task<IDataResult<List<User>>> GetAllUsersAsync()
    {
        var result = await _userDal.GetListAsync();
        return new SuccessDataResult<List<User>>(result);
    }

    public async Task<IDataResult<User>> GetUserAsync(Guid id)
    {
        var userToGet = await _userDal.GetAsync(u => u.Id == id);
        if (userToGet == null) return new ErrorDataResult<User>(UserMessages.UserNotFound);

        return new SuccessDataResult<User>(userToGet);
    }
    public async Task<IDataResult<User>> AddAsync(User user)
    {
        // Check User Code
        await _userDal.AddAsync(user);
        return new SuccessDataResult<User>(user,UserMessages.UserAdded);
    }

    public async Task<IDataResult<User>> UpdateUserAsync(User user)
    {
        var userToUpdate = await _userDal.GetAsync(u => u.Id == user.Id);
        if (userToUpdate == null) return new ErrorDataResult<User>(UserMessages.UserNotFound);

        userToUpdate = _mapper.Map(user, userToUpdate);
        return new SuccessDataResult<User>(userToUpdate, UserMessages.UserUpdated);
    }

    public async Task<IDataResult<User>> DeleteUserAsync(Guid id)
    {
        var userToDelete = await _userDal.GetAsync(u => u.Id == id);
        if (userToDelete == null) return new ErrorDataResult<User>(UserMessages.UserNotFound);

        await _userDal.DeleteAsync(userToDelete, true);
        return new SuccessDataResult<User>(userToDelete, UserMessages.UserDeleted);
    }
    public async Task<IResult> BanUserAsync(Guid id)
    {
        var userToBanned = await _userDal.GetAsync(u => u.Id ==  id);
        if (userToBanned == null) return new ErrorResult(UserMessages.UserNotFound);
        userToBanned.Status = false;
        await _userDal.UpdateAsync(userToBanned);
        return new SuccessDataResult<User>(UserMessages.UserBanned);
    }

    public async Task<IResult> UnBanUserAsync(Guid id)
    {
        var userToBanned = await _userDal.GetAsync(u => u.Id == id);
        if (userToBanned == null) return new ErrorResult(UserMessages.UserNotFound);
        userToBanned.Status = true;
        await _userDal.UpdateAsync(userToBanned);
        return new SuccessDataResult<User>(UserMessages.UserUnBanned);
    }

    public IDataResult<List<OperationClaim>> GetClaims(User user)
    {
        var result = _userDal.GetClaims(user);
        return new SuccessDataResult<List<OperationClaim>>(result);
    }

    public async Task<IDataResult<User>> GetByUserCodeAsync(string userCode)
    {
        var user = await _userDal.GetAsync(u => u.UserCode == userCode);
        if (user == null) return new ErrorDataResult<User>(UserMessages.UserNotFound);
        return new SuccessDataResult<User>(user);
    }
}
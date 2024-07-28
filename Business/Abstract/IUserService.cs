using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract;

public interface IUserService
{
    Task<IDataResult<List<User>>> GetAllUsersAsync();
    Task<IDataResult<User>> GetUserAsync(Guid id);
    Task<IDataResult<User>> AddAsync(User user);
    Task<IDataResult<User>> UpdateUserAsync(User user);
    Task<IDataResult<User>> DeleteUserAsync(Guid id);
    IDataResult<List<OperationClaim>> GetClaims(User user);
    Task<IDataResult<User>> GetByUserCodeAsync(string userCode);
}
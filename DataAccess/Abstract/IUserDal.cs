using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccess.Abstract;

public interface IUserDal : IAsyncRepository<User,Guid>
{
    List<OperationClaim> GetClaims(User user);
    List<OperationClaim> UpdateUserOperationClaims(User user, List<OperationClaim> userClaims);
    List<OperationClaim> DeleteUserOperationClaims(User user);
}
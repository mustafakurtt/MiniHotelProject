using Core.DataAccess;
using Core.Entities.Concrete;
using DataAccess.Concrete.Contexts;

namespace DataAccess.Abstract;

public interface IUserOperationClaim: IAsyncRepository<UserOperationClaim,Guid>
{
    
}
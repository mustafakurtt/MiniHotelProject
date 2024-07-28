using Core.DataAccess;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;

namespace DataAccess.Concrete;

public class UserOperationClaimDal : EntityRepositoryBase<UserOperationClaim,Guid,BaseContext>, IUserOperationClaim
{
    public UserOperationClaimDal(BaseContext context) : base(context)
    {
    }
}
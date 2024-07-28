using Core.DataAccess;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;

namespace DataAccess.Concrete;

public class OperationClaimdDal : EntityRepositoryBase<OperationClaim,Guid,BaseContext>, IOperationClaim
{
    public OperationClaimdDal(BaseContext context) : base(context)
    {
    }
}
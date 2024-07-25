using Core.DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete;

public class RoomDal : EntityRepositoryBase<Room,Guid,BaseContext> , IRoomDal
{
    public RoomDal(BaseContext context) : base(context)
    {
    }
}
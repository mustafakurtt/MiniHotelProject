using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IRoomTypeDal : IAsyncRepository<RoomType,Guid>
{
}
using Core.DataAccess;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace DataAccess.Concrete;

public class UserDal :EntityRepositoryBase<User,Guid,BaseContext> , IUserDal
{
    public UserDal(BaseContext context) : base(context)
    {
    }


    public List<OperationClaim> GetClaims(User user)
    {
        var query = Context.Set<UserOperationClaim>();
        query.AsNoTracking();
        query.Where(uoc => uoc.UserId == user.Id);
        query.Include(uoc => uoc.OperationClaim);
        var operationClaims = query.Select(uoc => uoc.OperationClaim).ToList();
        return operationClaims;
    }

    public List<OperationClaim> UpdateUserOperationClaims(User user, List<OperationClaim> userClaims)
    {
        var userOperationClaims = Context.Set<UserOperationClaim>()
            .Where(uoc => uoc.UserId == user.Id)
            .ToList();

        var existingClaimIds = userOperationClaims.Select(uoc => uoc.OperationClaimId).ToList();
        var newClaimIds = userClaims.Select(oc => oc.Id).Except(existingClaimIds).ToList();
        var deletedClaimIds = existingClaimIds.Except(userClaims.Select(oc => oc.Id)).ToList();

        foreach (var claimId in newClaimIds)
        {
            Context.Set<UserOperationClaim>().Add(new UserOperationClaim
            {
                UserId = user.Id,
                OperationClaimId = claimId
            });
        }

        foreach (var claimId in deletedClaimIds)
        {
            var userOperationClaim = userOperationClaims.FirstOrDefault(uoc => uoc.OperationClaimId == claimId);
            if (userOperationClaim != null)
            {
                Context.Set<UserOperationClaim>().Remove(userOperationClaim);
            }
        }

        Context.SaveChanges();

        var updatedClaims = Context.Set<UserOperationClaim>()
            .Where(uoc => uoc.UserId == user.Id)
            .Include(uoc => uoc.OperationClaim)
            .Select(uoc => uoc.OperationClaim)
            .ToList();

        return updatedClaims;
    }

    public List<OperationClaim> DeleteUserOperationClaims(User user)
    {
        var userOperationClaims = Context.Set<UserOperationClaim>()
            .Where(uoc => uoc.UserId == user.Id)
            .ToList();

        foreach (var userOperationClaim in userOperationClaims)
        {
            Context.Set<UserOperationClaim>().Remove(userOperationClaim);
        }

        Context.SaveChanges();
        var userClaims = Context.Set<UserOperationClaim>()
            .Where(uoc => uoc.UserId == user.Id)
            .Include(uoc => uoc.OperationClaim)
            .Select(uoc => uoc.OperationClaim)
            .ToList();
        return userClaims;
    }
}
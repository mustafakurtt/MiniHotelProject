using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;

public class ModerationManager : IModerationService
{
    private readonly IUserDal _userDal;
    private readonly IOperationClaim _operationClaim;
    private readonly IUserOperationClaim _userOperationClaim;
    private readonly IMapper _mapper;

    public ModerationManager(IUserDal userDal, IMapper mapper, IOperationClaim operationClaim, IUserOperationClaim userOperationClaim)
    {
        _userDal = userDal;
        _mapper = mapper;
        _operationClaim = operationClaim;
        _userOperationClaim = userOperationClaim;
    }


    public Task<IResult> BanUserAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> UnBanUserAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
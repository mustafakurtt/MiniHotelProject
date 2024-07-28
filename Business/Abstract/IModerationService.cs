using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract;

public interface IModerationService
{
    Task<IResult> BanUserAsync(Guid id);
    Task<IResult> UnBanUserAsync(Guid id);
}
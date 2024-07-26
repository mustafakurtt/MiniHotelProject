using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class RoomTypeValidator:AbstractValidator<RoomType>
{
    public RoomTypeValidator()
    {
        RuleFor(r => r.Name).NotEmpty();
        RuleFor(r => r.Name).MinimumLength(2);
        RuleFor(r => r.Name).MinimumLength(20);

        RuleFor(r => r.Description).NotEmpty();
        RuleFor(r => r.Description).MinimumLength(200);

        RuleFor(r => r.MaxGuestCount).GreaterThanOrEqualTo((short)0);
        RuleFor(r => r.MaxGuestCount).LessThanOrEqualTo((short)4);

        RuleFor(r => r.ImageUrl).NotEmpty();
        RuleFor(r => r.ImageUrl).MaximumLength(100);

    }
}
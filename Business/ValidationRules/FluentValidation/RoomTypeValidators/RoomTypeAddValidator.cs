using Entities.Concrete;
using Entities.DTOs.RoomTypeDTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.RoomTypeValidators;

public class RoomTypeAddValidator: AbstractValidator<RoomTypeAddRequestDto>
{
    public RoomTypeAddValidator()
    {
        RuleFor(r => r.Name).NotEmpty();
        RuleFor(r => r.Name).MinimumLength(2);
        RuleFor(r => r.Name).MaximumLength(20);

        RuleFor(r => r.Description).NotEmpty();
        RuleFor(r => r.Description).MaximumLength(200);

        RuleFor(r => r.MaxGuestCount).GreaterThanOrEqualTo((short)0);
        RuleFor(r => r.MaxGuestCount).LessThanOrEqualTo((short)4);

        RuleFor(r => r.ImageUrl).NotEmpty();
        RuleFor(r => r.ImageUrl).MaximumLength(100);
    }
}
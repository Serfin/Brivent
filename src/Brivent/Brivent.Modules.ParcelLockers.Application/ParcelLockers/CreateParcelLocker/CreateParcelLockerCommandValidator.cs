using FluentValidation;

namespace Brivent.Modules.ParcelLockers.Application.ParcelLockers
{
    public class CreateParcelLockerCommandValidator : AbstractValidator<CreateParcelLockerCommand>
    {
        public CreateParcelLockerCommandValidator()
        {
            this.RuleFor(x => x.Localization.City).NotEmpty()
                .WithMessage("Parcel locker city cannot be empty");

            this.RuleFor(x => x.Localization.Street).NotEmpty()
                .WithMessage("Parcel locker street cannot be empty");

            this.RuleFor(x => x.Localization.Latitude).InclusiveBetween(-90, 90)
                .WithMessage("Parcel locker latitude must be between -90 and 90 inclusive");

            this.RuleFor(x => x.Localization.Longtitude).InclusiveBetween(-180, 180)
                .WithMessage("Parcel locker longtitude must be between -180 and 180 inclusive");

            this.RuleFor(x => x.Localization.PostalCode).MaximumLength(6)
                .WithMessage("Invalid postal code format 'XX-XXX'");
        }
    }
}

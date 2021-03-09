using Brivent.Modules.Parcels.Domain;
using FluentValidation;

namespace Brivent.Modules.Parcels.Application.Parcels.CreateParcel
{
    public class CreateParcelCommandValidator : AbstractValidator<CreateParcelCommand>
    {
        public CreateParcelCommandValidator()
        {
            this.RuleFor(x => x.Size).InclusiveBetween((int)ParcelSize.Small, (int)ParcelSize.ExtraLarge)
                .WithMessage("Size of parcel cannot exceed the range of allowed sizes");

            this.RuleFor(x => x.Weight).GreaterThan(0)
                .WithMessage("Weight of parcel must be greater than 0");
        }
    }
}

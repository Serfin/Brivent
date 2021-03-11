using FluentValidation;

namespace Brivent.Modules.Parcels.Application.Parcels
{
    public class CreateParcelCommandValidator : AbstractValidator<CreateParcelCommand>
    {
        public CreateParcelCommandValidator()
        {
            this.RuleFor(x => x.Size).IsInEnum()
                .WithMessage("Size of parcel cannot exceed the range of allowed sizes");

            this.RuleFor(x => x.Weight).GreaterThan(0)
                .WithMessage("Weight of parcel must be greater than 0");
        }
    }
}

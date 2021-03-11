using FluentValidation;

namespace Brivent.Modules.Parcels.Application.Parcels
{
    public class DeleteParcelCommandValidator : AbstractValidator<DeleteParcelCommand>
    {
        public DeleteParcelCommandValidator()
        {
            this.RuleFor(x => x.Id).NotEmpty()
                .WithMessage("Parcel id cannot be empty");
        }
    }
}

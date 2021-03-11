using System;
using FluentValidation;

namespace Brivent.Modules.Parcels.Application.Parcels.UpdateParcel
{
    public class UpdateParcelCommandValidator : AbstractValidator<UpdateParcelCommand>
    {
        public UpdateParcelCommandValidator()
        {
            this.RuleFor(x => x.Id).NotEqual(Guid.Empty)
                .WithMessage("Parcel id cannot be empty");

            this.RuleFor(x => x.Status).IsInEnum()
                .WithMessage("Invalid parcel status");
        }
    }
}

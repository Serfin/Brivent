using System;
using Brivent.Modules.Parcels.Domain;
using FluentValidation;

namespace Brivent.Modules.Parcels.Application.Parcels.UpdateParcel
{
    public class UpdateParcelCommandValidator : AbstractValidator<UpdateParcelCommand>
    {
        public UpdateParcelCommandValidator()
        {
            this.RuleFor(x => x.Id).NotEqual(Guid.Empty)
                .WithMessage("Parcel id cannot be empty");

            this.RuleFor(x => (ParcelStatus)x.Status).IsInEnum()
                .WithMessage("Invalid parcel status");
        }
    }
}

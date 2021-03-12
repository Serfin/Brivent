using System;
using FluentValidation;

namespace Brivent.Modules.ParcelLockers.Application.ParcelLockerContentManagement.AddParcelToLocker
{
    public class AddParcelToLockerCommandValidator : AbstractValidator<AddParcelToLockerCommand>
    {
        public AddParcelToLockerCommandValidator()
        {
            this.RuleFor(x => x.ParcelLockerId).NotEqual(Guid.Empty)
                .WithMessage("Parcel id cannot be empty");

            this.RuleFor(x => x.ParcelsIds.Count).Empty()
                .WithMessage("List of parcels to add cannot be empty");
        }
    }
}

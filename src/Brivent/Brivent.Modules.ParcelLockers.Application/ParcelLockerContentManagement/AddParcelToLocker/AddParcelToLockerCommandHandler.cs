using System;
using System.Threading;
using System.Threading.Tasks;
using Brivent.Modules.ParcelLockers.Domain;
using MediatR;

namespace Brivent.Modules.ParcelLockers.Application.ParcelLockerContentManagement
{
    public class AddParcelToLockerCommandHandler : ICommandHandler<AddParcelToLockerCommand>
    {
        private readonly IParcelLockersRepository _parcelLockersRepository;

        public AddParcelToLockerCommandHandler(IParcelLockersRepository parcelLockersRepository)
        {
            _parcelLockersRepository = parcelLockersRepository;
        }

        public async Task<Unit> Handle(AddParcelToLockerCommand request, CancellationToken cancellationToken)
        {
            var parcelLocker = await _parcelLockersRepository.GetParcelLockerAsync(request.ParcelLockerId);

            if (parcelLocker is null)
            {
                throw new ApplicationException($"Parcel locker with id '{request.ParcelLockerId}' does not exist");
            }

            // TODO: Validate if parcels with given ids exists.
            foreach (var parcel in request.ParcelsIds)
            {
                parcelLocker.AddParcel(Parcel.Create(parcel));
            }

            await _parcelLockersRepository.UpdateParcelLockerAsync(parcelLocker);

            return Unit.Value;
        }
    }
}

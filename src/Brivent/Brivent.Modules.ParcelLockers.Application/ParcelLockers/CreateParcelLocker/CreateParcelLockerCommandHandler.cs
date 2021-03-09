using System;
using System.Threading;
using System.Threading.Tasks;
using Brivent.Modules.ParcelLockers.Domain;

namespace Brivent.Modules.ParcelLockers.Application.ParcelLockers
{
    public class CreateParcelLockerCommandHandler : ICommandHandler<CreateParcelLockerCommand, Guid>
    {
        private readonly IParcelLockersRepository _parcelLockersRepository;

        public CreateParcelLockerCommandHandler(IParcelLockersRepository parcelLockersRepository)
        {
            _parcelLockersRepository = parcelLockersRepository;
        }

        public async Task<Guid> Handle(CreateParcelLockerCommand command, CancellationToken cancellationToken)
        {
            var parcelLocker = ParcelLocker.Create(command.Localization, null);

            await _parcelLockersRepository.CreateParcelLockerAsync(parcelLocker);

            return parcelLocker.Id;
        }
    }
}

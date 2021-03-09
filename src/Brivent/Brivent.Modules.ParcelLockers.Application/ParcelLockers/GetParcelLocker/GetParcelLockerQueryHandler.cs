using System.Threading;
using System.Threading.Tasks;
using Brivent.Modules.ParcelLockers.Domain;

namespace Brivent.Modules.ParcelLockers.Application.ParcelLockers
{
    public class GetParcelLockerQueryHandler : IQueryHandler<GetParcelLockerQuery, ParcelLockerDto>
    {
        private readonly IParcelLockersRepository _parcelLockersRepository;

        public GetParcelLockerQueryHandler(IParcelLockersRepository parcelLockersRepository)
        {
            _parcelLockersRepository = parcelLockersRepository;
        }

        public async Task<ParcelLockerDto> Handle(GetParcelLockerQuery request, CancellationToken cancellationToken)
        {
            var parcelLocker = await _parcelLockersRepository.GetParcelLockerAsync(request.Id);

            if (!(parcelLocker is null))
            {
                return new ParcelLockerDto
                {
                    Id = parcelLocker.Id,
                    Localization = new ParcelLockerLocalizationDto
                    {
                        Latitude = parcelLocker.Localization.Latitude,
                        Longtitude = parcelLocker.Localization.Longtitude,
                        AdditionalInfo = parcelLocker.Localization.AdditionalInfo,
                        City = parcelLocker.Localization.City,
                        PostalCode = parcelLocker.Localization.PostalCode
                    }
                };
            }

            return null;
        }
    }
}

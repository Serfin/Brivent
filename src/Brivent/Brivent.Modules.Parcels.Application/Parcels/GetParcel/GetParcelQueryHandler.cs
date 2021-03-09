using System.Threading;
using System.Threading.Tasks;
using Brivent.Modules.Parcels.Domain;

namespace Brivent.Modules.Parcels.Application
{
    public class GetParcelQueryHandler : IQueryHandler<GetParcelQuery, ParcelDto>
    {
        private readonly IParcelRepository _parcelRepository;

        public GetParcelQueryHandler(IParcelRepository parcelRepository)
        {
            _parcelRepository = parcelRepository;
        }

        public async Task<ParcelDto> Handle(GetParcelQuery request, CancellationToken cancellationToken)
        {
            var parcel = await _parcelRepository.GetParcelAsync(request.Id);

            if (!(parcel is null))
            {
                return new ParcelDto
                {
                    Description = parcel.Description,
                    Size = (int)parcel.Size,
                    Weight = parcel.Weight
                };
            }

            return null;
        }
    }
}
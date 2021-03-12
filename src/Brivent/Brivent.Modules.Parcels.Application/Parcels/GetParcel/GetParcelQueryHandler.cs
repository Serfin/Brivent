using System.Threading;
using System.Threading.Tasks;
using Brivent.Modules.Parcels.Domain;

namespace Brivent.Modules.Parcels.Application.Parcels
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
                    Size = (int)parcel.Size,
                    Status = (int)parcel.Status,
                    Weight = parcel.Weight,
                    Description = parcel.Description,
                    CreateDate = parcel.CreateDate
                };
            }

            return null;
        }
    }
}
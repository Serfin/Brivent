using System;
using System.Threading;
using System.Threading.Tasks;
using Brivent.Modules.Parcels.Domain;

namespace Brivent.Modules.Parcels.Application.Parcels
{
    public class CreateParcelCommandHandler : ICommandHandler<CreateParcelCommand, Guid>
    {
        private readonly IParcelRepository _parcelRepository;

        public CreateParcelCommandHandler(
            IParcelRepository parcelRepository)
        {
            _parcelRepository = parcelRepository;
        }

        public async Task<Guid> Handle(CreateParcelCommand request, CancellationToken cancellationToken)
        {
            var parcel = Parcel.Create(request.Description, request.Weight, (ParcelSize)request.Size);

            await _parcelRepository.CreateParcelAsync(parcel);

            return parcel.Id;
        }
    }
}
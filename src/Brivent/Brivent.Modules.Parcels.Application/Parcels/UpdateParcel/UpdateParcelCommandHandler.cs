using System;
using System.Threading;
using System.Threading.Tasks;
using Brivent.Modules.Parcels.Domain;
using MediatR;

namespace Brivent.Modules.Parcels.Application.Parcels.UpdateParcel
{
    public class UpdateParcelCommandHandler : ICommandHandler<UpdateParcelCommand>
    {
        private readonly IParcelRepository _parcelRepository;

        public UpdateParcelCommandHandler(IParcelRepository parcelRepository)
        {
            _parcelRepository = parcelRepository;
        }

        public async Task<Unit> Handle(UpdateParcelCommand request, CancellationToken cancellationToken)
        {
            var parcel = await _parcelRepository.GetParcelAsync(request.Id);

            if (parcel is null)
            {
                throw new ApplicationException($"Parcel with id: '{request.Id}' does not exist");
            }

            parcel.SetStatus((ParcelStatus)request.Status);

            await _parcelRepository.UpdateParcelAsync(parcel);

            return Unit.Value;
        }
    }
}

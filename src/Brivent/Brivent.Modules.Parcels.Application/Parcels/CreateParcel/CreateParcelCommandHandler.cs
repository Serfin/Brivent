using System.Threading;
using System.Threading.Tasks;
using Brivent.Modules.Parcels.Domain;
using MediatR;

namespace Brivent.Modules.Parcels.Application
{
    public class CreateParcelCommandHandler : ICommandHandler<CreateParcelCommand>
    {
        private readonly IParcelRepository _parcelRepository;

        public CreateParcelCommandHandler(IParcelRepository parcelRepository)
        {
            _parcelRepository = parcelRepository;
        }

        public async Task<Unit> Handle(CreateParcelCommand request, CancellationToken cancellationToken)
        {
            var parcel = Parcel.Create(request.Description, request.Weight, (ParcelSize)request.Size);

            await _parcelRepository.CreateParcelAsync(parcel);

            return Unit.Value;
        }
    }
}
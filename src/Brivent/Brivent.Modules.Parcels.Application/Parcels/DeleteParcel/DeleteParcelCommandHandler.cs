using System;
using System.Threading;
using System.Threading.Tasks;
using Brivent.Modules.Parcels.Domain;
using MediatR;

namespace Brivent.Modules.Parcels.Application
{
    public class DeleteParcelCommandHandler : ICommandHandler<DeleteParcelCommand>
    {
        private readonly IParcelRepository _parcelsRepository;

        public DeleteParcelCommandHandler(IParcelRepository parcelsRepository)
        {
            _parcelsRepository = parcelsRepository;
        }

        public async Task<Unit> Handle(DeleteParcelCommand request, CancellationToken cancellationToken)
        {
            var parcel = await _parcelsRepository.GetParcelAsync(request.Id);

            if (parcel is null)
            {
                throw new ArgumentException($"Parcel with id: {request.Id} does not exist");
            }

            await _parcelsRepository.DeleteParcelAsync(parcel);

            return Unit.Value;
        }
    }
}

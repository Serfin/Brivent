using System;

namespace Brivent.Modules.Parcels.Application.Parcels
{
    public class GetParcelQuery : IQuery<ParcelDto>
    {
        public Guid Id { get; set; }
    }
}
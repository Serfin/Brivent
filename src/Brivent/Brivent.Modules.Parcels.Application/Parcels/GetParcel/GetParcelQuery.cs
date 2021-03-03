using System;

namespace Brivent.Modules.Parcels.Application
{
    public class GetParcelQuery : IQuery<ParcelDto>
    {
        public Guid Id { get; set; }
    }
}
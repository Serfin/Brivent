using System;

namespace Brivent.Modules.ParcelLockers.Application.ParcelLockers
{
    public class GetParcelLockerQuery : IQuery<ParcelLockerDto>
    {
        public Guid Id { get; set; }
    }
}

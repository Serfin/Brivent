using System;
using System.Threading.Tasks;
using Brivent.Modules.Parcels.Domain;

namespace Brivent.Modules.Parcels.Infrastructure
{
    public class ParcelRepository : IParcelRepository
    {
        public Task<Parcel> GetParcelAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
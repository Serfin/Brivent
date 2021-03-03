using System;
using System.Threading.Tasks;
using Brivent.Modules.Parcels.Domain;

namespace Brivent.Modules.Parcels.Infrastructure
{
    public class ParcelRepository : IParcelRepository
    {
        private readonly ParcelsContext _parcelsContext;
        public ParcelRepository(ParcelsContext parcelsContext)
        {
            _parcelsContext = parcelsContext;
        }

        public async Task CreateParcelAsync(Parcel parcel)
        {
            await _parcelsContext.AddAsync(parcel);
            await _parcelsContext.SaveChangesAsync();
        }

        public async Task<Parcel> GetParcelAsync(Guid id)
        {
            return await _parcelsContext.FindAsync<Parcel>(id);
        }
    }
}
using System;
using System.Threading.Tasks;
using Brivent.Modules.ParcelLockers.Domain;

namespace Brivent.Modules.ParcelLockers.Infrastructure
{
    public class ParcelLockersRepository : IParcelLockersRepository
    {
        private readonly ParcelLockersContext _parcelsContext;

        public ParcelLockersRepository(ParcelLockersContext parcelsContext)
        {
            _parcelsContext = parcelsContext;
        }

        public async Task CreateParcelLockerAsync(ParcelLocker parcelLocker)
        {
            await _parcelsContext.ParcelLockers.AddAsync(parcelLocker);
            await _parcelsContext.SaveChangesAsync();
        }

        public async Task<ParcelLocker> GetParcelLockerAsync(Guid id)
        {
            return await _parcelsContext.ParcelLockers.FindAsync(id);
        }

        public async Task UpdateParcelLockerAsync(ParcelLocker parcelLocker)
        {
            _parcelsContext.ParcelLockers.Update(parcelLocker);
            await _parcelsContext.SaveChangesAsync();
        }
    }
}
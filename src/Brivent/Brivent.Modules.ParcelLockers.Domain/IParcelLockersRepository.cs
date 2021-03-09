using System;
using System.Threading.Tasks;

namespace Brivent.Modules.ParcelLockers.Domain
{
    public interface IParcelLockersRepository
    {
        Task CreateParcelLockerAsync(ParcelLocker parcelLocker);
        Task<ParcelLocker> GetParcelLockerAsync(Guid id);
    }
}

using System;
using System.Threading.Tasks;

namespace Brivent.Modules.Parcels.Domain
{
    public interface IParcelRepository
    {
        Task CreateParcelAsync(Parcel parcel);
        Task<Parcel> GetParcelAsync(Guid id);
        Task DeleteParcelAsync(Parcel parcel);
    }
}
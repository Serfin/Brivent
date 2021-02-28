using System;
using System.Threading.Tasks;
using Brivent.Modules.Parcels.Domain;

namespace Brivent.Modules.Parcels.Domain
{
    public interface IParcelRepository
    {
        Task<Parcel> GetParcelAsync(Guid id);
    }
}
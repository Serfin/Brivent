using System;

namespace Brivent.Modules.ParcelLockers.Domain
{
    public class Parcel
    {
        public Guid ParcelId { get; private set; }

        private Parcel()
        {
            // EF Core constructor
        }

        private Parcel(Guid parcelId)
        {
            ParcelId = parcelId;
        }

        public static Parcel Create(Guid parcelId)
            => new Parcel(parcelId);
    }
}
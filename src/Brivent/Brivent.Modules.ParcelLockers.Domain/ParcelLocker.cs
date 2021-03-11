using System;
using System.Collections.Generic;

namespace Brivent.Modules.ParcelLockers.Domain
{
    public class ParcelLocker
    {
        public Guid Id { get; private set; }
        public ParcelLockerLocalization Localization { get; private set; }
        public List<Parcel> Parcels { get; private set; }

        private ParcelLocker()
        {
            // EF Core constructor
        }

        private ParcelLocker(ParcelLockerLocalization localization,
            List<Parcel> parcels)
        {
            Id = Guid.NewGuid();
            Localization = localization;
            Parcels = parcels;
        }

        public static ParcelLocker Create(ParcelLockerLocalization localization, List<Parcel> parcels)
            => new ParcelLocker(localization, parcels);
    }
}

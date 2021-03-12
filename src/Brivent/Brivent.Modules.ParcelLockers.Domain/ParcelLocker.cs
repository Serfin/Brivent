using System;
using System.Collections.Generic;
using Brivent.BuildingBlocks.Domain;

namespace Brivent.Modules.ParcelLockers.Domain
{
    public class ParcelLocker
    {
        public Guid Id { get; private set; }
        public ParcelLockerLocalization Localization { get; private set; }
        public List<Parcel> Parcels { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime? UpdateDate { get; private set; }

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
            CreateDate = DateTime.Now;
            UpdateDate = null;
        }

        public static ParcelLocker Create(ParcelLockerLocalization localization, List<Parcel> parcels)
            => new ParcelLocker(localization, parcels);

        public void AddParcel(Parcel parcel)
        {
            if (parcel is null)
            {
                throw new DomainValidationException($"Parameter {nameof(parcel)} cannot be null");
            }

            Parcels.Add(parcel);

            SetUpdateDate();
        }

        public void SetUpdateDate()
        {
            UpdateDate = DateTime.Now;
        }
    }
}

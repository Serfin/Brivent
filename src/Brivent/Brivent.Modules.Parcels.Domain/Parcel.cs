using System;

namespace Brivent.Modules.Parcels.Domain
{
    public class Parcel
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public float Weight { get; private set; }
        public ParcelSize Size { get; private set; }
        public ParcelStatus Status { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime? UpdateDate { get; private set; }

        private Parcel()
        {
            // EF Core constructor
        }

        private Parcel(string description, float weight, ParcelSize size)
        {
            Id = Guid.NewGuid();
            Description = description;
            Weight = weight;
            Size = size;
            Status = ParcelStatus.DuringPreparation;
            CreateDate = DateTime.Now;
            UpdateDate = null;
        }

        public static Parcel Create(string description, float weight, ParcelSize size)
            => new Parcel(description, weight, size);

        public void SetStatus(ParcelStatus parcelStatus)
        {
            Status = parcelStatus;
            SetUpdateDate();
        }

        private void SetUpdateDate()
        {
            UpdateDate = DateTime.Now;
        }
    }
}

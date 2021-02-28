using System;

namespace Brivent.Modules.Parcels.Domain
{
    public class Parcel
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public float Weight { get; private set; }
        public ParcelSize Size { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime UpdateDate { get; private set; }
        
        private Parcel()
        {
            // EF Core constructor
        }

        public Parcel(Guid id, string description, float weight, DateTime createDate, 
            DateTime updateDate)
        {
            Id = id;
            Description = description;
            Weight = weight;
            CreateDate = createDate;
            UpdateDate = updateDate;
        }
    }
}

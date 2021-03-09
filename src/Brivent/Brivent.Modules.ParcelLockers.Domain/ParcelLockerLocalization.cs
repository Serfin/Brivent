namespace Brivent.Modules.ParcelLockers.Domain
{
    public class ParcelLockerLocalization
    {
        public float Longtitude { get; private set; }
        public float Latitude { get; private set; }
        public string AdditionalInfo { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string Street { get; private set; }

        public ParcelLockerLocalization(float longtitude, float latitude, 
            string additionalInfo, string city, string postalCode, string street)
        {
            Longtitude = longtitude;
            Latitude = latitude;
            AdditionalInfo = additionalInfo;
            PostalCode = postalCode;
            City = city;
            Street = street;
        }
    }
}
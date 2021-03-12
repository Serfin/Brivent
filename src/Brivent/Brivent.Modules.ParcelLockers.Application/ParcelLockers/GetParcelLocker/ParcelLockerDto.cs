using System;

namespace Brivent.Modules.ParcelLockers.Application.ParcelLockers
{
    public class ParcelLockerDto
    {
        public Guid Id { get; set; }
        public ParcelLockerLocalizationDto Localization { get; set; }
        public DateTime CreateDate { get; set; }
    }
}

using System;

namespace Brivent.Modules.Parcels.Application.Parcels
{
    public class ParcelDto
    {
        public string Description { get; set; }
        public float Weight { get; set; }
        public int Size { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
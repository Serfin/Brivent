using System;
using Brivent.Modules.Parcels.Domain;

namespace Brivent.Modules.Parcels.Application.Parcels
{
    public class CreateParcelCommand : ICommand<Guid>
    {
        public string Description { get; set; }
        public float Weight { get; set; }
        public ParcelSize Size { get; set; }
    }
}
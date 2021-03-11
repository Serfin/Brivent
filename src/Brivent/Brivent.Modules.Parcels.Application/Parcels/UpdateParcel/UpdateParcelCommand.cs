using System;
using Brivent.Modules.Parcels.Domain;

namespace Brivent.Modules.Parcels.Application.Parcels
{
    public class UpdateParcelCommand : ICommand
    {
        public Guid Id { get; set; }
        public ParcelStatus Status { get; set; }
    }
}

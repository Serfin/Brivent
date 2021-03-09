using System;
using Brivent.Modules.ParcelLockers.Domain;

namespace Brivent.Modules.ParcelLockers.Application.ParcelLockers
{
    public class CreateParcelLockerCommand : ICommand<Guid>
    {
        public ParcelLockerLocalization Localization { get; set; }
    }
}

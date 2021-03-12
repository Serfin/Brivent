using System;
using System.Collections.Generic;

namespace Brivent.Modules.ParcelLockers.Application.ParcelLockerContentManagement
{
    public class AddParcelToLockerCommand : ICommand
    {
        public Guid ParcelLockerId { get; set; }
        public List<Guid> ParcelsIds { get; set; }
    }
}

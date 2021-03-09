using System;

namespace Brivent.Modules.Parcels.Application
{
    public class DeleteParcelCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}

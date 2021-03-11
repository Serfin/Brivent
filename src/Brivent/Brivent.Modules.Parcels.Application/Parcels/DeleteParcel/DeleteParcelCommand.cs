using System;

namespace Brivent.Modules.Parcels.Application.Parcels
{
    public class DeleteParcelCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}

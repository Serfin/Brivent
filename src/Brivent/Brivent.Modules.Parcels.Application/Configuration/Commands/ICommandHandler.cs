using MediatR;

namespace Brivent.Modules.Parcels.Application
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
        where TCommand : ICommand
    {
         
    }
}
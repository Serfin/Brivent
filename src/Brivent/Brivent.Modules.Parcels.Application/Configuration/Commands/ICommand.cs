using MediatR;

namespace Brivent.Modules.Parcels.Application
{
    public interface ICommand : IRequest
    {
    }

    public interface ICommand<out TResult> : IRequest<TResult>
    {
    }
}
using MediatR;

namespace Brivent.Modules.ParcelLockers.Application
{
    public interface ICommand : IRequest
    {
    }

    public interface ICommand<out TResult> : IRequest<TResult>
    {
    }
}
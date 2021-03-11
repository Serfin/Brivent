using MediatR;

namespace Brivent.Modules.ParcelLockers.Application
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}
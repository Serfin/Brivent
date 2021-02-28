using MediatR;

namespace Brivent.Modules.Parcels.Application
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
        
    }
}
using MediatR;

namespace Brivent.Modules.ParcelLockers.Application
{
    public interface IQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {

    }
}
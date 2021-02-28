using MediatR;

namespace Brivent.Modules.Parcels.Application
{
    public interface IQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
         
    }
}
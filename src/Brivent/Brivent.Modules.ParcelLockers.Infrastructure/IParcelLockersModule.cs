using System.Threading.Tasks;
using Brivent.Modules.ParcelLockers.Application;

namespace Brivent.Modules.ParcelLockers.Infrastructure
{
    public interface IParcelLockersModule
    {
        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);
        Task ExecuteCommandAsync(ICommand command);
        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
    }
}
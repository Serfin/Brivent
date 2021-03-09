using System.Threading.Tasks;
using Brivent.Modules.Parcels.Application;

namespace Brivent.Modules.Parcels.Infrastructure
{
    public interface IParcelsModule
    {
        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);
        Task ExecuteCommandAsync(ICommand command);
        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
    }
}
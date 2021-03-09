using System.Threading.Tasks;
using Autofac;
using Brivent.Modules.ParcelLockers.Application;
using Brivent.Modules.ParcelLockers.Infrastructure.Configuration;
using MediatR;

namespace Brivent.Modules.ParcelLockers.Infrastructure
{
    public class ParcelLockersModule : IParcelLockersModule
    {
        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
        {
            return await CommandsExecutor.Execute(command);
        }

        public async Task ExecuteCommandAsync(ICommand command)
        {
            await CommandsExecutor.Execute(command);
        }

        public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
        {
            using (var scope = ParcelLockersCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                return await mediator.Send(query);
            }
        }
    }
}

using System.Threading.Tasks;
using Autofac;
using Brivent.Modules.Parcels.Application;
using Brivent.Modules.Parcels.Infrastructure.Configuration;
using MediatR;

namespace Brivent.Modules.Parcels.Infrastructure
{
    public class ParcelsModule : IParcelsModule
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
            using (var scope = ParcelsCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                return await mediator.Send(query);
            }
        }
    }
}

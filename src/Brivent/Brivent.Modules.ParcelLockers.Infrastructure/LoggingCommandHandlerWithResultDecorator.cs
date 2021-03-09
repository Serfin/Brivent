using System;
using System.Threading;
using System.Threading.Tasks;
using Brivent.Modules.ParcelLockers.Application;
using Serilog;

namespace Brivent.Modules.ParcelLockers.Infrastructure
{
    public class LoggingCommandHandlerWithResultDecorator<T, TResult> : ICommandHandler<T, TResult>
        where T : ICommand<TResult>
    {
        private readonly ILogger _logger;
        private readonly ICommandHandler<T, TResult> _decoratedHandler;

        public LoggingCommandHandlerWithResultDecorator(
            ILogger logger, 
            ICommandHandler<T, TResult> decoratedHandler)
        {
            _logger = logger;
            _decoratedHandler = decoratedHandler;
        }

        public async Task<TResult> Handle(T command, CancellationToken cancellationToken)
        {
            try
            {
                _logger.Information("Executing {Command}", command.GetType().Name);

                var result = await _decoratedHandler.Handle(command, cancellationToken);

                _logger.Information("Command {Command} processed successful", command.GetType().Name);

                return result;

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Command {Command} processing failed", command.GetType().Name);
                throw;
            }
        }
    }
}

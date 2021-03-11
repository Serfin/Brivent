using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Brivent.BuildingBlocks.Application;
using Brivent.Modules.Parcels.Application;
using FluentValidation;

namespace Brivent.Modules.Parcels.Infrastructure
{
    public class ValidationCommandHandlerWithResultDecorator<T, TResult> : ICommandHandler<T, TResult>
        where T : ICommand<TResult>
    {
        private readonly IList<IValidator<T>> _validators;
        private readonly ICommandHandler<T, TResult> _decoratedHandler;

        public ValidationCommandHandlerWithResultDecorator(
            IList<IValidator<T>> validators,
            ICommandHandler<T, TResult> decoratedHandler)
        {
            _validators = validators;
            _decoratedHandler = decoratedHandler;
        }

        public Task<TResult> Handle(T command, CancellationToken cancellationToken)
        {
            var validationErrors = _validators
                .Select(v => v.Validate(command))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (validationErrors.Any())
            {
                throw new CommandValidationException(validationErrors.Select(x => x.ErrorMessage).ToList());
            }

            return _decoratedHandler.Handle(command, cancellationToken);
        }
    }
}

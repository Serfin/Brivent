using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Brivent.BuildingBlocks.Application;
using Brivent.Modules.Parcels.Application;
using FluentValidation;
using MediatR;

namespace Brivent.Modules.Parcels.Infrastructure
{
    public class ValidationCommandHandlerDecorator<T> : ICommandHandler<T>
        where T : ICommand
    {
        private readonly IList<IValidator<T>> _validators;
        private readonly ICommandHandler<T> _decoratedHandler;

        public ValidationCommandHandlerDecorator(
            IList<IValidator<T>> validators, 
            ICommandHandler<T> decoratedHandler)
        {
            _validators = validators;
            _decoratedHandler = decoratedHandler;
        }

        public Task<Unit> Handle(T command, CancellationToken cancellationToken)
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

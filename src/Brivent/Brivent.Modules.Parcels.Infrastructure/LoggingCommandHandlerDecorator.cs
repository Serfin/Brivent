﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Brivent.Modules.Parcels.Application;
using MediatR;

namespace Brivent.Modules.Parcels.Infrastructure
{
    public class LoggingCommandHandlerDecorator<T> : ICommandHandler<T>
        where T : ICommand
    {
        private readonly ICommandHandler<T> _decoratedHandler;

        public LoggingCommandHandlerDecorator(ICommandHandler<T> decoratedHandler)
        {
            _decoratedHandler = decoratedHandler;
        }

        public Task<Unit> Handle(T request, CancellationToken cancellationToken)
        {
            return _decoratedHandler.Handle(request, cancellationToken);
        }
    }
}

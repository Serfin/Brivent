using Autofac;
using Brivent.Modules.Parcels.Application;
using FluentValidation;
using MediatR;

namespace Brivent.Modules.Parcels.Infrastructure.Autofac
{
    public class MediatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register Mediator
            builder.RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            var registrationTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(IValidator<>)
            };

            foreach (var registrationType in registrationTypes)
            {
                builder.RegisterAssemblyTypes(typeof(ICommand).Assembly, ThisAssembly)
                    .AsClosedTypesOf(registrationType)
                    .AsImplementedInterfaces()
                    .FindConstructorsWith(new AllConstructorFinder());
            }

            builder.Register<ServiceFactory>(context =>
            {
                var componentContent = context.Resolve<IComponentContext>();
                return t => componentContent.Resolve(t);
            }).InstancePerLifetimeScope();
        }
    }
}

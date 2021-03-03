using Autofac;
using Brivent.Modules.Parcels.Application;
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

            builder.Register<ServiceFactory>(context =>
            {
                var componentContent = context.Resolve<IComponentContext>();
                return t => componentContent.Resolve(t);
            });

            // Register CommandHandlers
            builder.RegisterAssemblyTypes(typeof(ICommandHandler<>).Assembly, ThisAssembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}

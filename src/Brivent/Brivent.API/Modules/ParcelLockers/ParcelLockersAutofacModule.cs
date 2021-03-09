using Autofac;
using Brivent.Modules.ParcelLockers.Infrastructure;

namespace Brivent.API.Modules.ParcelLockers
{
    public class ParcelLockersAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ParcelLockersModule>()
                .As<IParcelLockersModule>()
                .InstancePerLifetimeScope();
        }
    }
}

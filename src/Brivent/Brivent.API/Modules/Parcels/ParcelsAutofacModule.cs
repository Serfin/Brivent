using Autofac;
using Brivent.Modules.Parcels.Infrastructure;

namespace Brivent.API.Modules.Parcels
{
    public class ParcelsAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ParcelsModule>()
                .As<IParcelsModule>()
                .InstancePerLifetimeScope();
        }
    }
}

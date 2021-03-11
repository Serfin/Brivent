using Autofac;
using Brivent.Modules.Parcels.Infrastructure.Autofac;
using Brivent.Modules.Parcels.Infrastructure.Configuration;
using Brivent.Modules.Parcels.Infrastructure.Logging;
using Serilog.Extensions.Logging;
using ILogger = Serilog.ILogger;

namespace Brivent.Modules.Parcels.Infrastructure
{
    public class ParcelsStartup
    {
        private static IContainer _container;

        public static void Initialize(
            string connectionString,
            ILogger logger)
        {
            var moduleLogger = logger.ForContext("Module", "Parcels");
            ConfigureCompositionRoot(connectionString, moduleLogger);
        }

        private static void ConfigureCompositionRoot(
            string connectionString,
            ILogger moduleLogger)
        {
            var containerBuilder = new ContainerBuilder();
            var loggerFactory = new SerilogLoggerFactory(moduleLogger);

            containerBuilder.RegisterModule(new LoggingModule(moduleLogger));
            containerBuilder.RegisterModule(new DataAccessModule(connectionString, loggerFactory));
            containerBuilder.RegisterModule(new MediatorModule());
            containerBuilder.RegisterModule(new ProcessingModule());

            _container = containerBuilder.Build();

            ParcelsCompositionRoot.SetContainer(_container);
        }
    }
}

using Autofac;
using Brivent.Modules.ParcelLockers.Infrastructure.Autofac;
using Brivent.Modules.ParcelLockers.Infrastructure.Configuration;
using Brivent.Modules.ParcelLockers.Infrastructure.Logging;
using Serilog.Extensions.Logging;
using ILogger = Serilog.ILogger;

namespace Brivent.Modules.ParcelLockers.Infrastructure
{
    public class ParcelLockersStartup
    {
        private static IContainer _container;

        public static void Initialize(
            string connectionString,
            ILogger logger)
        {
            var moduleLogger = logger.ForContext("Module", "ParcelLockers");
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

            ParcelLockersCompositionRoot.SetContainer(_container);
        }
    }
}

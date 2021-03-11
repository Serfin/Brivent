using System.Linq;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Brivent.Modules.ParcelLockers.Infrastructure.Autofac
{
    public class DataAccessModule : Module
    {
        private readonly string _connectionString;
        private readonly ILoggerFactory _loggerFactory;

        public DataAccessModule(string connectionString, ILoggerFactory loggerFactory)
        {
            _connectionString = connectionString;
            _loggerFactory = loggerFactory;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var infrastructureAssembly = typeof(DataAccessModule).Assembly;

            builder.RegisterAssemblyTypes(infrastructureAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder
                .Register(c =>
                {
                    var dbContextOptionsBuilder = new DbContextOptionsBuilder<ParcelLockersContext>();
                    dbContextOptionsBuilder.UseSqlServer(_connectionString);

                    return new ParcelLockersContext(dbContextOptionsBuilder.Options);
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();
        }
    }
}

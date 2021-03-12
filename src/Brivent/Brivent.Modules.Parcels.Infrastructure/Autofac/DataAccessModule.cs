using System.Linq;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Brivent.Modules.Parcels.Infrastructure.Autofac
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

            builder.Register(c =>
            {
                var dbContextOptionsBuilder = new DbContextOptionsBuilder<ParcelsContext>();
                dbContextOptionsBuilder.UseLoggerFactory(_loggerFactory);
                dbContextOptionsBuilder.UseSqlServer(_connectionString, x =>
                {
                    x.CommandTimeout(30);
                    x.EnableRetryOnFailure(3);
                });

                return new ParcelsContext(dbContextOptionsBuilder.Options);
            })
            .AsSelf()
            .InstancePerLifetimeScope();
        }
    }
}

using Autofac;
using Microsoft.EntityFrameworkCore;

namespace Brivent.Modules.Parcels.Infrastructure.Autofac
{
    public class ParcelsModule : Module
    {
        private readonly string _connectionString;
        public ParcelsModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var infrastructureAssembly = typeof(ParcelsModule).Assembly;

            builder.RegisterAssemblyTypes(infrastructureAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.Register(c =>
            {
                var dbContextOptionsBuilder = new DbContextOptionsBuilder<ParcelsContext>();
                dbContextOptionsBuilder.UseSqlServer(_connectionString);

                return new ParcelsContext(dbContextOptionsBuilder.Options);
            })
            .AsSelf()
            .InstancePerLifetimeScope();
        }
    }
}

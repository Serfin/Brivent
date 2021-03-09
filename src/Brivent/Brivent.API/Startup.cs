using Autofac;
using Brivent.API.Configuration.Validation;
using Brivent.API.Modules.ParcelLockers;
using Brivent.API.Modules.Parcels;
using Brivent.Modules.ParcelLockers.Infrastructure;
using Brivent.Modules.Parcels.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Brivent.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private static ILogger _logger;
        private static ILogger _loggerForApi;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            ConfigureLogger();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        private static void ConfigureLogger()
        {
            _logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console(
                    outputTemplate:
                    "[{Timestamp:HH:mm:ss} {Level:u3}] [{Module}] [{Context}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            _loggerForApi = _logger.ForContext("Module", "API");

            _loggerForApi.Information("Logger configured");
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            // Register mediator communication layer
            containerBuilder.RegisterModule(new ParcelsAutofacModule());
            containerBuilder.RegisterModule(new ParcelLockersAutofacModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            InitializeModules();

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void InitializeModules()
        {
            // Register modules dependencies
            ParcelsStartup.Initialize(Configuration.GetConnectionString("parcels"), _logger);
            ParcelLockersStartup.Initialize(Configuration.GetConnectionString("parcelLockers"), _logger);
        }
    }
}

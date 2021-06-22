using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Microsoft.Extensions.Options;
using Parkhaus.Controllers;
using DataLibary.DataAccess;
using DataLibary.BusinessLogic;

namespace Parkhaus
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.Configure<DatabaseSettings>(Configuration)
                .AddSingleton(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

            services.AddSingleton<WeatherForecastController>();
            services.AddTransient<ISqlDataAccess, MySqlDataAccess>();
            services.AddTransient<IGarageProcessor, GarageProcessor>();
            services.AddTransient<IParkTicketProcessor, ParkTicketProcessor>();

            services.AddFluentMigratorCore()
                .ConfigureRunner(config =>
                    config.AddMySql5()
                    .WithGlobalConnectionString(Configuration.GetValue("ConnectionString", string.Empty))
                    .ScanIn(Assembly.GetAssembly(typeof(DataLibary.DataAccess.MySqlDataAccess))).For.Migrations())
                .AddLogging(config => config.AddFluentMigratorConsole());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });

            using var scope = app.ApplicationServices.CreateScope();
            var migrator = scope.ServiceProvider.GetService<IMigrationRunner>();
            migrator.MigrateDown(0);
            migrator.MigrateUp();
        }
    }
}

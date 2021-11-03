using Domain.RapidPay.Logic;
using Domain.RapidPay.UseCasesPorts;
using Drivers.RapidPay.Repository;
using InterfaceAdapters.RapidPay.Authentication;
using InterfaceAdapters.RapidPay.Middlewares;
using InterfaceAdapters.RapidPay.Presenters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Presentation.RapidPay
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureLogic();

            services.ConfigureRepository(Configuration);

            services.ConfigureUseCasesInteractors();

            services.ConfigurePresenters();

            services.AddAuthentication("Basic")
                    .AddScheme<BasicAuthenticationOptions, BasicAuthenticationHandler>("Basic", opt =>
                    {
                    });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
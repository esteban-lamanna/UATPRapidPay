using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RapidPay.Authentication;
using RapidPay.Logic;
using RapidPay.Middlewares;
using RapidPay.Repository;

namespace RapidPay
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
            services.AddTransient<IUserLoginLogic, UserLoginLogic>();
            services.AddTransient<ICardBalanceLogic, CardBalanceLogic>();
            services.AddSingleton<IFeeLogic, FeeLogic>();
            services.AddTransient<IPaymentLogic, PaymentLogic>();

            services.AddDbContext<RapidPayContext>();

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
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UATPRapidPay.Card.Api.Middlewares;

namespace UATPRapidPay.Card.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<ExceptionsMiddleware>();

            services.ConfigureServices(_configuration);

            services.AddAuthentication(o =>
            {
                o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, o =>
            {
                
                o.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                o.Authority = "https://localhost:5001";
                o.ClientId = "RapidPayIDP";
                o.ResponseType = "code";
                o.UsePkce = false;
                o.Scope.Add("openid");
                o.Scope.Add("profile");
                o.SaveTokens = true;
                o.ClientSecret = "privatesecret";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<ExceptionsMiddleware>();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
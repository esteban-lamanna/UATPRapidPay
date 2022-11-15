using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Okta.AspNetCore;

namespace RapidPay.Identity.Presentacion.Okta
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
      //      services.AddSwaggerGen();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });

            services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowAll",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
             .AddCookie(c =>
             {
                 c.
             })
             .AddOktaMvc(new OktaMvcOptions
             {
                 OktaDomain = _configuration.GetValue<string>("Okta:OktaDomain"),
                 AuthorizationServerId = _configuration.GetValue<string>("Okta:AuthorizationServerId"),
                 ClientId = _configuration.GetValue<string>("Okta:ClientId"),
                 ClientSecret = _configuration.GetValue<string>("Okta:ClientSecret"),
                 Scope = new List<string> { "openid", "profile", "email" },
             });

            services.AddAuthorization();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
      //      app.UseSwagger();
      //      app.UseSwaggerUI();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors();
            app.UseHttpsRedirection();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
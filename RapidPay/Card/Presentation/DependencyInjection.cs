using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using UATPRapidPay.Card.Api.Authorization;
using UATPRapidPay.Card.Application;
using UATPRapidPay.Card.Domain;
using UATPRapidPay.Card.Infrastructure;

namespace UATPRapidPay.Card.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplication();
            services.AddDomain();
            services.AddInfrastructure(configuration);
            return services;
        }
    }
}
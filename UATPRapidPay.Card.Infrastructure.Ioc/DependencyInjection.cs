using Microsoft.Extensions.DependencyInjection;
using UATPRapidPay.Card.Application;
using UATPRapidPay.Card.Domain;
using UATPRapidPay.Card.Infrastructure.SqlServer;

namespace UATPRapidPay.Card.Infrastructure.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureIoC(this IServiceCollection services)
        {
            services.AddApplication();
            services.AddDomain();
            services.AddRepositories();

            return services;
        }
    }
}
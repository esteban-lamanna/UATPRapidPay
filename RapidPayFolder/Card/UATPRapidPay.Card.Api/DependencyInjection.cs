using Microsoft.Extensions.DependencyInjection;
using UATPRapidPay.Card.Infrastructure.Ioc;

namespace UATPRapidPay.Card.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.ConfigureIoC();

            return services;
        }
    }
}
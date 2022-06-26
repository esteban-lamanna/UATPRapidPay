using Microsoft.Extensions.DependencyInjection;

namespace UATPRapidPay.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICardRepository, CardRepository>();
            return services;
        }
    }
}
using Microsoft.Extensions.DependencyInjection;
using UATPRapidPay.Card.Domain.Factories;

namespace UATPRapidPay.Card.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<ICardFactory, CardFactory>();
            return services;
        }
    }
}
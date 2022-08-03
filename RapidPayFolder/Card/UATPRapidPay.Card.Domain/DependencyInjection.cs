using Microsoft.Extensions.DependencyInjection;
using UATPRapidPay.Card.Domain.Factories;

namespace UATPRapidPay.Card.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddSingleton<ICardFactory, CardFactory>();
            services.AddSingleton<ICardNumberFactory, CardNumberFactory>();
            services.AddSingleton<IPersonFactory, PersonFactory>();

            return services;
        }
    }
}
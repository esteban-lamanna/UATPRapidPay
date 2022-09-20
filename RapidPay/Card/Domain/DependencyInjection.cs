using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Internal;
using UATPRapidPay.Card.Domain.Factories;

namespace UATPRapidPay.Card.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddTransient<ICardFactory, CardFactory>();
            services.AddTransient<ICardNumberFactory, CardNumberFactory>();
            services.AddSingleton<IPersonFactory, PersonFactory>();
            services.AddScoped<ISystemClock, SystemClock>();

            return services;
        }
    }
}
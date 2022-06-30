using Microsoft.Extensions.DependencyInjection;
using UATPRapidPay.Card.Application.Commands;
using UATPRapidPay.Card.Application.Services;

namespace UATPRapidPay.Card.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddCommandHandlers();
            services.AddCommandDispatcher();
            services.AddServices();

            return services;
        }

        private static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            return services;
        }

        private static IServiceCollection AddCommandDispatcher(this IServiceCollection services)
        {
            services.AddTransient<ICommandDispatcher, CommandDispatcher>();
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICardService, CardService>();
            return services;
        }
    }
}
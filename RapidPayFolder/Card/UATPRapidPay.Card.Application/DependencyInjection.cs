using Microsoft.Extensions.DependencyInjection;
using UATPRapidPay.Card.Application.Commands;
using UATPRapidPay.Card.Application.Commands.Handlers;
using UATPRapidPay.Card.Application.Queries;
using UATPRapidPay.Card.Application.Services;
using UATPRapidPay.Shared.Commands;
using UATPRapidPay.Shared.Queries;

namespace UATPRapidPay.Card.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddCommandHandlers();
            services.AddCommandDispatcher();
            services.AddQueryDispatcher();
            services.AddServices();

            return services;
        }

        private static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            services.AddTransient<ICommandHandler<CreateCardCommand>, CreateCardCommandHandler>();
            services.AddTransient<ICommandHandler<CreatePersonCommand>, CreatePersonCommandHandler>();

            return services;
        }

        private static IServiceCollection AddCommandDispatcher(this IServiceCollection services)
        {
            services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
            return services;
        }

        private static IServiceCollection AddQueryDispatcher(this IServiceCollection services)
        {
            services.AddSingleton<IQueryDispatcher, QueryDispatcher>();
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICardService, CardService>();
            return services;
        }
    }
}
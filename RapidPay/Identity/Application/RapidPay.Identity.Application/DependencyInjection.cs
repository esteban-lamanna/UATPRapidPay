using Microsoft.Extensions.DependencyInjection;
using RapidPay.Identity.Application.Commands;
using RapidPay.Identity.Application.Commands.Handlers;
using UATPRapidPay.Shared.Commands;

namespace RapidPay.Identity.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddCommandHandlers();
            services.AddCommandDispatcher();
            return services;
        }

        private static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            services.AddTransient<ICommandHandler<LoginCommand>, LoginCommandHandler>();

            return services;
        }

        private static IServiceCollection AddCommandDispatcher(this IServiceCollection services)
        {
            services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
            return services;
        }
    }
}
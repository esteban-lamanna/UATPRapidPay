﻿using Microsoft.Extensions.DependencyInjection;
using UATPRapidPay.Card.Application.Commands;

namespace UATPRapidPay.Card.Application
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
            return services;
        }

        private static IServiceCollection AddCommandDispatcher(this IServiceCollection services)
        {
            services.AddTransient<ICommandDispatcher, CommandDispatcher>();
            return services;
        }
    }
}
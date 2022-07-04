﻿using Microsoft.Extensions.DependencyInjection;
using UATPRapidPay.Card.Application;
using UATPRapidPay.Card.Domain;
using UATPRapidPay.Card.Infrastructure;

namespace UATPRapidPay.Card.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddApplication();
            services.AddDomain();
            services.AddInfrastructure();

            return services;
        }
    }
}
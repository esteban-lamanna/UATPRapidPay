﻿using Domain.RapidPay.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Drivers.RapidPay.Repository
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ConfigureRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RapidPayContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RapidPay.EnterpriseBusinessRules.Entities;
using RapidPay.EnterpriseBusinessRules.Entities.Repositories;
using RapidPay.InterfaceAdapters.Gateways.Repository.EF.Implementations;

namespace RapidPay.InterfaceAdapters.Gateways.Repository.EF
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ConfigureRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RapidPayContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IUserLoginRepository, UserLoginRepository>();

            return services;
        }
    }
}
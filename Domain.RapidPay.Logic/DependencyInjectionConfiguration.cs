using Microsoft.Extensions.DependencyInjection;

namespace RapidPay.ApplicationBusinessRules.UseCases.Logic
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ConfigureLogic(this IServiceCollection services)
        {
            services.AddScoped<ICardBalanceLogic, CardBalanceLogic>();
            services.AddSingleton<IFeeLogic, FeeLogic>();
            services.AddScoped<IPaymentLogic, PaymentLogic>();

            return services;
        }
    }
}
using Microsoft.Extensions.DependencyInjection;

namespace Domain.RapidPay.Logic
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ConfigureLogic(this IServiceCollection services)
        {
            services.AddScoped<IUserLoginLogic, UserLoginLogic>();
            services.AddScoped<ICardBalanceLogic, CardBalanceLogic>();
            services.AddSingleton<IFeeLogic, FeeLogic>();
            services.AddScoped<IPaymentLogic, PaymentLogic>();

            return services;
        }
    }
}
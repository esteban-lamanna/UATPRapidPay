using Microsoft.Extensions.DependencyInjection;

namespace Domain.RapidPay.Logic
{
    public static class DependencyInjectionConfiguration
    {
        public static void ConfigureLogic(this IServiceCollection services)
        {
            services.AddTransient<IUserLoginLogic, UserLoginLogic>();
            services.AddTransient<ICardBalanceLogic, CardBalanceLogic>();
            services.AddSingleton<IFeeLogic, FeeLogic>();
            services.AddTransient<IPaymentLogic, PaymentLogic>();
        }
    }
}
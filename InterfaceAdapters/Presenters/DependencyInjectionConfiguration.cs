using Microsoft.Extensions.DependencyInjection;
using RapidPay.ApplicationBusinessRules.UseCases.UseCasesPort.CreateCard;
using RapidPay.ApplicationBusinessRules.UseCases.UseCasesPort.GetAllCards;
using RapidPay.ApplicationBusinessRules.UseCases.UseCasesPort.LoginUser;

namespace RapidPay.InterfaceAdapters.Presenters
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ConfigurePresenters(this IServiceCollection services)
        {
            services.AddScoped<ICreateCardOutputPort, CreateCardPresenter>();
            services.AddScoped<IGetAllCardsOutputPort, GetAllCardsPresenter>();
            services.AddScoped<ILoginUserOutputPort, LoginUserPresenter>();

            return services;
        }
    }
}
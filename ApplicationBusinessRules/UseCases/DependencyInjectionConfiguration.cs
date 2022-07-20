using Microsoft.Extensions.DependencyInjection;
using RapidPay.ApplicationBusinessRules.UseCases.UseCasesPort.CreateCard;
using RapidPay.ApplicationBusinessRules.UseCases.UseCasesPort.GetAllCards;
using RapidPay.ApplicationBusinessRules.UseCases.UseCasesPort.LoginUser;

namespace RapidPay.ApplicationBusinessRules.UseCases
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ConfigureUseCasesInteractors(this IServiceCollection services)
        {
            services.AddScoped<ICreateCardInputPort, CreateCardInteractor>();
            services.AddScoped<IGetAllCardsInputPort, GetAllCardsInteractor>();
            services.AddScoped<ILoginUserInputPort, LoginUserInteractor>();

            return services;
        }
    }
}
using Domain.RapidPay.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.RapidPay.UseCasesPorts
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
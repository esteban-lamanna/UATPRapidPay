using Domain.RapidPay.UseCasesPorts;
using Microsoft.Extensions.DependencyInjection;

namespace InterfaceAdapters.RapidPay.Presenters
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
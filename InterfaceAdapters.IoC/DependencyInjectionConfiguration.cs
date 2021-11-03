using Domain.RapidPay.Logic;
using Domain.RapidPay.UseCasesPorts;
using Drivers.RapidPay.Repository;
using InterfaceAdapters.RapidPay.Presenters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InterfaceAdapters.RapidPay.IoC
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureLogic();

            services.ConfigureRepository(configuration);

            services.ConfigureUseCasesInteractors();

            services.ConfigurePresenters();

            return services;
        }
    }
}
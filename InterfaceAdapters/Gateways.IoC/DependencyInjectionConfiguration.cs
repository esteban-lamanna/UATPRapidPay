using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RapidPay.ApplicationBusinessRules.UseCases;
using RapidPay.ApplicationBusinessRules.UseCases.Logic;
using RapidPay.InterfaceAdapters.Gateways.Repository.EF;
using RapidPay.InterfaceAdapters.Presenters;

namespace RapidPay.InterfaceAdapters.Gateways.IoC
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
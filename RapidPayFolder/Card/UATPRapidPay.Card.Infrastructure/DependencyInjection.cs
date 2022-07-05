using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UATPRapidPay.Card.Application.DTO;
using UATPRapidPay.Card.Application.Queries;
using UATPRapidPay.Card.Infrastructure.EF;
using UATPRapidPay.Card.Infrastructure.Queries.Handlers;
using UATPRapidPay.Shared;
using UATPRapidPay.Shared.Queries;

namespace UATPRapidPay.Card.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddQueries();

            configuration.GetOptions<DatabaseOptions>("Application:Database");

            services.AddDbContext<ReadDbContext>();

            return services;
        }

        private static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddTransient<IQueryHandler<GetCardQuery, GetCardDTO>, GetCardQueryHandler>();
            return services;
        }
    }
}
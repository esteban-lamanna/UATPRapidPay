using Microsoft.EntityFrameworkCore;
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

            var connection = configuration.GetConnectionString("ConnectionString");

            services.AddDbContext<ReadDbContext>(options =>
            {
                options.UseSqlServer(connection);
                options.UseLazyLoadingProxies();
            });

            services.AddDbContext<WriteDbContext>(options =>
            {
                options.UseSqlServer(connection);
                options.UseLazyLoadingProxies();
            });

            return services;
        }

        private static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddTransient<IQueryHandler<GetCardQuery, GetCardDTO>, GetCardQueryHandler>();
            return services;
        }
    }
}
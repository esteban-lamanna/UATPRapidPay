using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UATPRapidPay.Card.Application.DTO;
using UATPRapidPay.Card.Application.Queries;
using UATPRapidPay.Card.Domain.Repositories;
using UATPRapidPay.Card.Infrastructure.EF;
using UATPRapidPay.Card.Infrastructure.Queries.Handlers;
using UATPRapidPay.Card.Infrastructure.Repositories;
using UATPRapidPay.Shared.Queries;

namespace UATPRapidPay.Card.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddQueries();

            services.AddRepositories();

            string? connection = configuration.GetConnectionString("ConnectionString");

            services.AddDbContext<ReadDbContext>(options =>
            {
                options.UseSqlServer(connection);
            });

            services.AddDbContext<WriteDbContext>(options =>
            {
                options.UseSqlServer(connection);
            });

            return services;
        }

        private static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddTransient<IQueryHandler<GetCardQuery, GetCardDTO>, GetCardQueryHandler>();
            services.AddTransient<IQueryHandler<GetPersonQuery, GetPersonDTO>, GetPersonQueryHandler>();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICardRepository, CardRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();

            return services;
        }
    }
}
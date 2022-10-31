using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UATPRapidPay.Identity.Infrastructure.EF;

namespace RapidPay.Identity.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddRepositories();

            //services.AddEventProcessor();

            string? connection = configuration.GetConnectionString("ConnectionString");

            //services.AddDbContext<ReadDbContext>(options =>
            //{
            //    options.UseSqlServer(connection);
            //});

            services.AddDbContext<WriteDbContext>(options =>
            {
                options.UseSqlServer(connection);
            });

            return services;
        }

    }
}

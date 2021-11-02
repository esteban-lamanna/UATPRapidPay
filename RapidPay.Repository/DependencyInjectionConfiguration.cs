using Domain.RapidPay.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence.RapidPay.Repository
{
    public static class DependencyInjectionConfiguration
    {
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddDbContext<RapidPayContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
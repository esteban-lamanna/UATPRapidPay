using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RapidPay.InterfaceAdapters.Gateways.Repository.EF
{
    public class RapidPayContext : DbContext
    {
        readonly IConfiguration _configuration;

        public RapidPayContext(DbContextOptions<RapidPayContext> options, IConfiguration configuration)
           : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var assembly = typeof(RapidPayContext).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLazyLoadingProxies();

            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("sqlServer"));
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Persistence.RapidPay.Repository
{
    public class RapidPayContext : DbContext
    {
        public object HostBuilderExtensions { get; private set; }

        readonly IConfiguration _configuration;

        public RapidPayContext(DbContextOptions<RapidPayContext> options, IConfiguration configuration)
           : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("RapidPay"));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLazyLoadingProxies();

            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("sqlServer"));
        }
    }
}
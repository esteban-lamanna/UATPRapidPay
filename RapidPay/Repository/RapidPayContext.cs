using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace RapidPay.Repository
{
    public class RapidPayContext : DbContext
    {
        public RapidPayContext(DbContextOptions<RapidPayContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetEntryAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}

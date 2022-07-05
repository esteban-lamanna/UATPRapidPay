using Microsoft.EntityFrameworkCore;
using UATPRapidPay.Card.Infrastructure.EF.Configuration;

namespace UATPRapidPay.Card.Infrastructure.EF
{
    internal class WriteDbContext : DbContext
    {
        public DbSet<Domain.Entities.Card> Cards { get; set; }
        public DbSet<Domain.Entities.Person> Persons { get; set; }
        public DbSet<Domain.Entities.Purchase> Purchases { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configuration = new WriteConfiguration();
            modelBuilder.ApplyConfiguration<Card.Domain.Entities.Card>(configuration);
            modelBuilder.ApplyConfiguration<Card.Domain.Entities.Purchase>(configuration);
            modelBuilder.ApplyConfiguration<Card.Domain.Entities.Person>(configuration);
            base.OnModelCreating(modelBuilder);
        }
    }
}
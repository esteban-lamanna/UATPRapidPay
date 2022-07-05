using Microsoft.EntityFrameworkCore;
using UATPRapidPay.Card.Infrastructure.EF.Configuration;
using UATPRapidPay.Card.Infrastructure.Models;

namespace UATPRapidPay.Card.Infrastructure.EF
{
    internal class ReadDbContext : DbContext
    {
        public DbSet<ReadPersonModel> Persons { get; set; }
        public DbSet<ReadCardModel> Cards { get; set; }
        public DbSet<ReadPurchaseModel> Purchases { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configuration = new ReadConfiguration();
            modelBuilder.ApplyConfiguration<ReadCardModel>(configuration);
            modelBuilder.ApplyConfiguration<ReadPersonModel>(configuration);
            modelBuilder.ApplyConfiguration<ReadPurchaseModel>(configuration);   

            base.OnModelCreating(modelBuilder);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using RapidPay.Identity.Domain.Entities;
using UATPRapidPay.Identity.Infrastructure.EF.Configuration;

namespace UATPRapidPay.Identity.Infrastructure.EF
{
    internal class WriteDbContext : DbContext
    {
        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        //Add-migration initial -StartupProject UATPRapidPay.Card.Api -OutputDir EF/Migrations -Context WriteDbContext
        //Update-Database -Context WriteDbContext


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configuration = new WriteConfiguration();
            modelBuilder.ApplyConfiguration<User>(configuration);
            base.OnModelCreating(modelBuilder);
        }
    }
}
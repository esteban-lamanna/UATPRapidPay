﻿using Microsoft.EntityFrameworkCore;
using UATPRapidPay.Card.Infrastructure.EF.Configuration;
using UATPRapidPay.Card.Infrastructure.Models;

namespace UATPRapidPay.Card.Infrastructure.EF
{
    internal class ReadDbContext : DbContext
    {
        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configuration = new ReadConfiguration();
            modelBuilder.ApplyConfiguration<ReadCardModel>(configuration);
            modelBuilder.ApplyConfiguration<ReadPersonModel>(configuration);
            modelBuilder.ApplyConfiguration<ReadPurchaseModel>(configuration);   

            // Add-migration initial -StartupProject UATPRapidPay.Card.Api -OutputDir EF/Migrations -Context ReadDbContext
            // Update-Database -Context ReadDbContext

            base.OnModelCreating(modelBuilder);
        }
    }
}
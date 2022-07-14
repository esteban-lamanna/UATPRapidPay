﻿using Microsoft.EntityFrameworkCore;
using UATPRapidPay.Card.Infrastructure.EF.Configuration;

namespace UATPRapidPay.Card.Infrastructure.EF
{
    internal class WriteDbContext : DbContext
    {
        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configuration = new WriteConfiguration();
            modelBuilder.ApplyConfiguration<Domain.Entities.Card>(configuration);
            modelBuilder.ApplyConfiguration<Domain.Entities.Purchase>(configuration);
            modelBuilder.ApplyConfiguration<Domain.Entities.Person>(configuration);
            base.OnModelCreating(modelBuilder);
        }
    }
}
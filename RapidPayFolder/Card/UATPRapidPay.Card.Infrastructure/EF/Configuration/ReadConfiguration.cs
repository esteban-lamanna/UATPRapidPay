using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UATPRapidPay.Card.Infrastructure.Models;

namespace UATPRapidPay.Card.Infrastructure.EF.Configuration
{
    internal class ReadConfiguration : IEntityTypeConfiguration<ReadCardModel>,
                                       IEntityTypeConfiguration<ReadPersonModel>,
                                       IEntityTypeConfiguration<ReadPurchaseModel>
    {
        public void Configure(EntityTypeBuilder<ReadPersonModel> builder)
        {
            builder.ToTable("Persons");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.HasMany(x => x.Cards).WithOne(c=>c.Person);
        }

        public void Configure(EntityTypeBuilder<ReadCardModel> builder)
        {
            builder.ToTable("Cards");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Number);
            builder.Property(x => x.Limit);
            builder.Property(x => x.ExpirationDate);
            builder.HasMany(d => d.ProductsBougth).WithOne(a=>a.Card);            
            builder.HasOne(a => a.Person).WithMany(a => a.Cards);
        }

        public void Configure(EntityTypeBuilder<ReadPurchaseModel> builder)
        {
            builder.ToTable("Purchases");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProductName);
            builder.Property(x => x.Price);
            builder.Property(x => x.PurchaseDate);
            builder.HasOne(a => a.Card).WithMany(a => a.ProductsBougth);
        }
    }
}
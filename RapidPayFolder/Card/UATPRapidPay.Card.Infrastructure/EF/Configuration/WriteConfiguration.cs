using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using UATPRapidPay.Card.Domain.Entities;
using UATPRapidPay.Card.Domain.ValueObjects;

namespace UATPRapidPay.Card.Infrastructure.EF.Configuration
{
    internal class WriteConfiguration : IEntityTypeConfiguration<Domain.Entities.Card>,
                                        IEntityTypeConfiguration<Person>,
                                        IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            var personNameConverter = new ValueConverter<Name, string>(
                    n => n.Value,
                    s => new Name(s));

            var personEmailConverter = new ValueConverter<Email, string>(
                    e => e.Value,
                    s => new Email(s));

            builder.ToTable("Persons");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
            builder.Property(x => x.Name).HasConversion(personNameConverter).HasColumnName("Name").HasMaxLength(30).IsRequired();
            builder.Property(x => x.Email).HasConversion(personEmailConverter).HasColumnName("Email").HasMaxLength(300).IsRequired();

            builder.Ignore(a => a.Cards);
            builder.HasMany<Domain.Entities.Card>("_cards").WithOne(p=>p.Person).OnDelete(DeleteBehavior.Cascade);
        }

        public void Configure(EntityTypeBuilder<Domain.Entities.Card> builder)
        {
            var cardExpirationDateConverter = new ValueConverter<ExpirationDate, DateTime>(
                    e => e.Value.ToDateTime(new TimeOnly(0, 0, 0)),
                    s => new ExpirationDate(new DateOnly(s.Year, s.Month, s.Day)));

            var cardNumberConverter = new ValueConverter<CardNumber, string>(
                    e => e.Number,
                    s => new CardNumber(s));

            builder.ToTable("Cards");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
            builder.Property(x => x.CardNumber).HasConversion(cardNumberConverter).HasColumnName("CardNumber").HasMaxLength(16).IsRequired();
            builder.Property(x => x.Limit).HasColumnName("Limit").IsRequired().HasColumnType("decimal(8,2)");
            builder.Property(x => x.ExpirationDate).HasConversion(cardExpirationDateConverter).HasColumnName("ExpirationDate").IsRequired();

            builder.Ignore(a => a.ProductsBougth);
            builder.Property<Guid>("IdPerson").IsRequired();
            builder.HasOne(a => a.Person).WithMany("_cards").HasForeignKey("IdPerson");
            builder.HasMany<Purchase>("_productsBougth").WithOne(p => p.Card).OnDelete(DeleteBehavior.Cascade);
        }

        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            var purchaseProductNameConverter = new ValueConverter<ProductName, string>(
                  e => e.Value,
                  s => new ProductName(s));

            var purchaseDateConverter = new ValueConverter<PurchaseDate, DateTime>(
                  e => e.Value,
                  s => new PurchaseDate(s));

            builder.ToTable("Purchases");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
            builder.Property(x => x.ProductName).HasColumnName("ProductName").HasMaxLength(30).IsRequired().HasConversion(purchaseProductNameConverter);
            builder.Property(x => x.Price).HasColumnName("Price").IsRequired().HasColumnType("decimal(8,2)");
            builder.Property(x => x.PurchaseDate).HasColumnName("PurchaseDate").IsRequired().HasConversion(purchaseDateConverter);

            builder.Property<Guid>("IdCard").IsRequired();
            builder.HasOne(a => a.Card).WithMany("_productsBougth").HasForeignKey("IdCard");
        }
    }
}
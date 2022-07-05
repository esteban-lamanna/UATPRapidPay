using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
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
                    n => n.ToString(), 
                    s => new Name(s));

            var personEmailConverter = new ValueConverter<Email, string>(
                    e => e.ToString(),
                    s => new Email(s));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasConversion(personNameConverter);
            builder.Property(x => x.Email).HasConversion(personEmailConverter);
            builder.HasMany(x => x.Cards).WithOne(c => c.Person);
        }

        public void Configure(EntityTypeBuilder<Card.Domain.Entities.Card> builder)
        {
            var cardExpirationDateConverter = new ValueConverter<ExpirationDate, DateOnly>(
                    e => e.Value,
                    s => new ExpirationDate(s));

            var cardNumberConverter = new ValueConverter<CardNumber, string>(
                    e => e.Number,
                    s => new CardNumber(s));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.CardNumber).HasConversion(cardNumberConverter);
            builder.Property(x => x.Limit);
            builder.Property(x => x.ExpirationDate).HasConversion(cardExpirationDateConverter);
            builder.HasMany(d => d.ProductsBougth).WithOne(a => a.Card);
            builder.HasOne(a => a.Person).WithMany(a => a.Cards);
        }

        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProductName);
            builder.Property(x => x.Price);
            builder.Property(x => x.PurchaseDate);
            builder.HasOne(a => a.Card).WithMany(a => a.ProductsBougth);
        }
    }
}
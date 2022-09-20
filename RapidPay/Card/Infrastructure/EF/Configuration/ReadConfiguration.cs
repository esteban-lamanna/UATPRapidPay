using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
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
            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
            builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(30).IsRequired();
            builder.Property(x => x.Email).HasColumnName("Email").HasMaxLength(300).IsRequired();
        }

        public void Configure(EntityTypeBuilder<ReadCardModel> builder)
        {
            var dateOnlyConverter = new ValueConverter<DateOnly, DateTime>(
                  date => new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, DateTimeKind.Utc),
                  dt => DateOnly.FromDateTime(dt));

            builder.ToTable("Cards");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
            builder.Property(x => x.Number).HasColumnName("CardNumber").HasMaxLength(16).IsRequired();
            builder.Property(x => x.Limit).HasColumnName("Limit").HasColumnType("decimal(8,2)").IsRequired();
            builder.Property(x => x.ExpirationDate).HasConversion(dateOnlyConverter).HasColumnName("ExpirationDate").IsRequired();
        }

        public void Configure(EntityTypeBuilder<ReadPurchaseModel> builder)
        {
            //builder.ToTable("Purchases");

            //builder.HasKey(x => x.Id);
            //builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
            //builder.Property(x => x.ProductName).HasColumnName("ProductName").IsRequired().HasMaxLength(30);
            //builder.Property(x => x.Price).HasColumnName("Price").HasColumnType("decimal(8,2)").IsRequired();
            //builder.Property(x => x.PurchaseDate).HasColumnName("PurchaseDate").IsRequired();
            //builder.HasOne(a => a.Card).WithMany(a => a.ProductsBougth).HasForeignKey(a => a.IdCard).HasConstraintName("FK_Purchases_Cards").OnDelete(DeleteBehavior.Restrict);
        }
    }
}
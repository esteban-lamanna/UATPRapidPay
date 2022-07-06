﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UATPRapidPay.Card.Infrastructure.EF;

#nullable disable

namespace UATPRapidPay.Card.Infrastructure.EF.Migrations
{
    [DbContext(typeof(ReadDbContext))]
    partial class ReadDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("cards")
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UATPRapidPay.Card.Infrastructure.Models.ReadCardModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ExpirationDate");

                    b.Property<int>("IdPerson")
                        .HasColumnType("int");

                    b.Property<decimal>("Limit")
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("Limit");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)")
                        .HasColumnName("Number");

                    b.HasKey("Id");

                    b.HasIndex("IdPerson");

                    b.ToTable("Cards", "cards");
                });

            modelBuilder.Entity("UATPRapidPay.Card.Infrastructure.Models.ReadPersonModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Persons", "cards");
                });

            modelBuilder.Entity("UATPRapidPay.Card.Infrastructure.Models.ReadPurchaseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdCard")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("Price");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("ProductName");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("PurchaseDate");

                    b.HasKey("Id");

                    b.HasIndex("IdCard");

                    b.ToTable("Purchases", "cards");
                });

            modelBuilder.Entity("UATPRapidPay.Card.Infrastructure.Models.ReadCardModel", b =>
                {
                    b.HasOne("UATPRapidPay.Card.Infrastructure.Models.ReadPersonModel", "Person")
                        .WithMany("Cards")
                        .HasForeignKey("IdPerson")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Cards_Persons");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("UATPRapidPay.Card.Infrastructure.Models.ReadPurchaseModel", b =>
                {
                    b.HasOne("UATPRapidPay.Card.Infrastructure.Models.ReadCardModel", "Card")
                        .WithMany("ProductsBougth")
                        .HasForeignKey("IdCard")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Purchases_Cards");

                    b.Navigation("Card");
                });

            modelBuilder.Entity("UATPRapidPay.Card.Infrastructure.Models.ReadCardModel", b =>
                {
                    b.Navigation("ProductsBougth");
                });

            modelBuilder.Entity("UATPRapidPay.Card.Infrastructure.Models.ReadPersonModel", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}

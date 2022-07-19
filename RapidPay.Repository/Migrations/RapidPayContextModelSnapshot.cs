﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using RapidPay.InterfaceAdapters.Gateways.Repository.EF;

namespace RapidPay.Migrations
{
    [DbContext(typeof(RapidPayContext))]
    partial class RapidPayContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RapidPay.Logic.Entities.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Available")
                        .HasColumnName("Available")
                        .HasColumnType("decimal(8,2)");

                    b.Property<int>("IdUser")
                        .HasColumnName("IdUser")
                        .HasColumnType("int");

                    b.Property<byte[]>("LastModification")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("LastModification")
                        .HasColumnType("rowversion");

                    b.Property<decimal>("Limit")
                        .HasColumnName("Limit")
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnName("Number")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("RapidPay.Logic.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnName("Amount")
                        .HasColumnType("decimal(8,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnName("Date")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Fee")
                        .HasColumnName("Fee")
                        .HasColumnType("decimal(8,2)");

                    b.Property<int>("IdCard")
                        .HasColumnName("IdCard")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnName("IdUser")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCard");

                    b.HasIndex("IdUser");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("RapidPay.Logic.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "estebanlamanna@hotmail.com",
                            Password = "abcdef"
                        });
                });

            modelBuilder.Entity("RapidPay.Logic.Entities.Card", b =>
                {
                    b.HasOne("RapidPay.Logic.Entities.User", "User")
                        .WithMany("Cards")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK_Cards_Users")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("RapidPay.Logic.Entities.Payment", b =>
                {
                    b.HasOne("RapidPay.Logic.Entities.Card", "Card")
                        .WithMany("Payments")
                        .HasForeignKey("IdCard")
                        .HasConstraintName("FK_Payments_Cards")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RapidPay.Logic.Entities.User", "User")
                        .WithMany("Payments")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK_Payments_Users")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

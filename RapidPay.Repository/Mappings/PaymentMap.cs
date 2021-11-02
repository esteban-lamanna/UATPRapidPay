using Domain.RapidPay.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.RapidPay.Repository.Mappings
{
    public class PaymentMap : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Date).HasColumnName("datetime").IsRequired();
            builder.Property(a => a.IdUser).HasColumnName("IdUser").IsRequired();
            builder.Property(a => a.IdCard).HasColumnName("IdCard").IsRequired();
            builder.Property(a => a.Amount).HasColumnName("Amount").IsRequired().HasColumnType("decimal(8,2)");
            builder.Property(a => a.Fee).HasColumnName("Fee").IsRequired().HasColumnType("decimal(8,2)");
            builder.Property(a => a.Date).HasColumnName("Date").IsRequired().HasColumnType("datetime");

            builder.HasOne(a => a.Card).WithMany(a => a.Payments).HasForeignKey(a => a.IdCard).HasConstraintName("FK_Payments_Cards").OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.User).WithMany(a => a.Payments).HasForeignKey(a => a.IdUser).HasConstraintName("FK_Payments_Users").OnDelete(DeleteBehavior.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidPay.Logic.Entities;

namespace RapidPay.Repository.Mappings
{
    public class CardMap : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.ToTable("Cards");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Number).HasColumnName("Number").HasMaxLength(15).IsRequired();
            builder.Property(a => a.IdUser).HasColumnName("IdUser").IsRequired();
            builder.Property(a => a.Limit).HasColumnName("Limit").IsRequired().HasColumnType("decimal(8,2)");

            builder.HasOne(a => a.User).WithMany(a => a.Cards).HasForeignKey(a => a.IdUser).HasConstraintName("FK_Cards_Users").OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(a => a.Payments).WithOne(a => a.Card);
        }
    }
}
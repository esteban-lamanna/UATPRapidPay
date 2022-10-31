using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidPay.Identity.Domain.Entities;

namespace UATPRapidPay.Identity.Infrastructure.EF.Configuration
{
    internal class WriteConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
            builder.Property(x => x.Role).HasColumnName("Role").HasMaxLength(30).IsRequired();
            builder.Property(x => x.Password).HasColumnName("Password").HasMaxLength(300).IsRequired();
            builder.Property(x => x.Email).HasColumnName("Email").HasMaxLength(300).IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidPay.Logic.Entities;

namespace RapidPay.Repository.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Email).HasColumnName("Email").IsRequired();
            builder.Property(a => a.Password).HasColumnName("Password").IsRequired();

            builder.HasMany(a => a.Cards).WithOne(a => a.User);
            builder.HasMany(a => a.Payments).WithOne(a => a.User);

            builder.HasData(new User()
            {
                Email = "estebanlamanna@hotmail.com",
                Password = "abcdef",
                Id = 1
            });
        }
    }
}
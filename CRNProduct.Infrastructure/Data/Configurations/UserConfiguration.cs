using CRNProduct.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRNProduct.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Password)
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(x => x.Role)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(x => x.RefreshToken)
                   .HasMaxLength(500);

            builder.Property(x => x.RefreshTokenExpiryTime);
        }
    }
}
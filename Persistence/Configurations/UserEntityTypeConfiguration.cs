using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class UserEntityTypeConfiguration : BasicEntityTypeConfiguration<User>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.Property(p => p.Email)
                .HasColumnName("Email")
                .IsRequired();

            builder.Property(p => p.FirstName)
                .HasColumnName("FirstName")
                .IsRequired();

            builder.Property(p => p.SecondName)
                .HasColumnName("SecondName")
                .IsRequired();

            builder.Property(p => p.Password)
                .HasColumnName("Password")
                .IsRequired();

            builder.Property(p => p.RoleId)
                .HasColumnName("RoleId")
                .IsRequired();

            builder.HasOne(s => s.Role)
            .WithMany(g => g.Users)
            .HasForeignKey(s => s.RoleId);
        }
    }
}

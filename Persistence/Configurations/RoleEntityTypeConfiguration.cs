using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class RoleEntityTypeConfiguration : BasicEntityTypeConfiguration<Role>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");

            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .IsRequired();

            builder.Property(p => p.Type)
                .HasColumnName("Type")
                .IsRequired();
        }
    }
}

using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal class RecipeEntityTypeConfiguration : BasicEntityTypeConfiguration<Recipe>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Recipe> builder)
        {
            builder.ToTable("Recipes");

            builder.Property(p => p.Name)
               .HasColumnName("Name")
               .IsRequired();
            builder.Property(p => p.Price)
               .HasColumnName("Price")
               .IsRequired();
            builder.Property(p => p.Ingredients)
               .HasColumnName("Ingredients")
               .IsRequired();
            builder.Property(p => p.Available)
               .HasColumnName("Available")
               .IsRequired(); 
            builder.Property(p => p.Quantity)
               .HasColumnName("Quantity")
               .IsRequired();
        }
    }
}

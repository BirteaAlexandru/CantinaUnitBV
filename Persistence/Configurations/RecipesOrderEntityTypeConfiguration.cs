using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal class RecipesOrderEntityTypeConfiguration : BasicEntityTypeConfiguration<RecipesOrder>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<RecipesOrder> builder)
        {
            builder.ToTable("RecipesOrder");

            builder.Property(p => p.OrderId)
               .HasColumnName("OrderId")
               .IsRequired();
            builder.Property(p => p.RecipeId)
               .HasColumnName("RecipeId")
               .IsRequired();

            builder.HasOne(s => s.Order)
            .WithMany(g => g.RecipesOrders)
            .HasForeignKey(s => s.OrderId);
            builder.HasOne(s => s.Recipe)
            .WithMany(g => g.RecipesOrders)
            .HasForeignKey(s => s.RecipeId);
        }
    }
}

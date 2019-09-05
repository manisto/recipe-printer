using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipes.Domain.Models;

namespace Recipes.Infrastructure.EntityConfigurations
{
    public class RecipeCategoryConfiguration : IEntityTypeConfiguration<RecipeCategory>
    {
        public void Configure(EntityTypeBuilder<RecipeCategory> builder)
        {
            builder
                .HasIndex("RecipeId", "CategoryId")
                .IsUnique();

            builder
                .HasOne(rc => rc.Recipe)
                .WithMany(r => r.RecipeCategories)
                .IsRequired();

            builder
                .HasOne(rc => rc.Category)
                .WithMany()
                .IsRequired();
        }
    }
}
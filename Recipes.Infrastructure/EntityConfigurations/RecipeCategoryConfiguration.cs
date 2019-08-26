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
                .HasKey(bc => new { CategoryId = bc.Category.Id, RecipeId = bc.Recipe.Id });

            builder
                .HasOne(rc => rc.Recipe)
                .WithMany(r => r.RecipeCategories);

            builder
                .HasOne(rc => rc.Category)
                .WithMany();
        }
    }
}
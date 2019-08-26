using Microsoft.EntityFrameworkCore;
using Recipes.Domain.Models;
using Recipes.Infrastructure.EntityConfigurations;

namespace Recipes.Infrastructure
{
    public class RecipesDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }

        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Recipes.sqlite");
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RecipeCategoryConfiguration());
        }
    }
}
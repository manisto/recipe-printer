using Microsoft.EntityFrameworkCore;
using Recipes.Domain.Models;

namespace Recipes.Infrastructure
{
    public class RecipesDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }

        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Recipes.db");
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
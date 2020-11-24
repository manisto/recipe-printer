using Microsoft.EntityFrameworkCore;
using Recipes.Domain.Models;
using Recipes.Domain.Repositories;
using Recipes.Infrastructure.EntityConfigurations;
using System.IO;
using FileContextCore;

namespace Recipes.Infrastructure
{
    public class RecipesDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }

        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigureFile(optionsBuilder);
        }

        private void ConfigureFile(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine(".", "data");
            optionsBuilder.UseFileContextDatabase(location: path);
        }

        private void ConfigureSqlite(DbContextOptionsBuilder optionsBuilder)
        {
            Directory.CreateDirectory("data");
            string path = Path.Combine(".", "data", "Recipes.sqlite");
            optionsBuilder.UseSqlite($"Data Source={path}");
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RecipeCategoryConfiguration());
        }
    }
}
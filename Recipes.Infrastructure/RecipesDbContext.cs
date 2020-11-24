using Microsoft.EntityFrameworkCore;
using Recipes.Domain.Models;
using Recipes.Domain.Repositories;
using Recipes.Infrastructure.EntityConfigurations;
using System.IO;
using FileContextCore;
using Microsoft.Extensions.Configuration;

namespace Recipes.Infrastructure
{
    public class RecipesDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }

        private readonly string _path;

        public RecipesDbContext(IConfiguration configuration)
        {
            _path = configuration.GetValue("DataPath", "./data");
        }

        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigureFile(optionsBuilder);
        }

        private void ConfigureFile(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseFileContextDatabase(location: _path);
        }

        private void ConfigureSqlite(DbContextOptionsBuilder optionsBuilder)
        {
            Directory.CreateDirectory(_path);
            optionsBuilder.UseSqlite($"Data Source={_path}");
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RecipeCategoryConfiguration());
        }
    }
}
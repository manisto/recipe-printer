using System.Collections.Generic;
using Recipes.Domain.Repositories;
using Recipes.Domain.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Recipes.Infrastructure.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipesDbContext _context;

        public RecipeRepository
        (
            RecipesDbContext context
        )
        {
            _context = context;
        }

        public async Task<Category> GetCategoryAsync(int categoryId)
        {
            return await _context.Categories.FindAsync(categoryId);
        }

        public async Task<IEnumerable<Category>> ListCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Recipe> GetRecipeAsync(int recipeId)
        {
            return await _context.Recipes.FindAsync(recipeId);
        }
    }
}
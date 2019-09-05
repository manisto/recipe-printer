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

        public IUnitOfWork UnitOfWork => _context;

        public RecipeRepository
        (
            RecipesDbContext context
        )
        {
            _context = context;
        }

        public async Task<Recipe> GetRecipeAsync(int recipeId)
        {
            return await _context.Recipes.FindAsync(recipeId);
        }

        public async Task<IEnumerable<Recipe>> ListRecipesAsync()
        {
            return await _context.Recipes.ToListAsync();
        }

        public void AddRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
        }
    }
}
using Recipes.Domain.Repositories;
using Recipes.Domain.Models;
using System.Threading.Tasks;

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

        public async Task<Recipe> GetRecipeAsync(int recipeId)
        {
            return await _context.Recipes.FindAsync(recipeId);
        }
    }
}
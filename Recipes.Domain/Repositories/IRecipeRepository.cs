using System.Collections.Generic;
using Recipes.Domain.Models;
using System.Threading.Tasks;

namespace Recipes.Domain.Repositories
{
    public interface IRecipeRepository : IRepository
    {
        Task<Recipe> GetRecipeAsync(int recipeId);
        Task<IEnumerable<Recipe>> ListRecipesAsync();

        void AddRecipe(Recipe recipe);
    }
}
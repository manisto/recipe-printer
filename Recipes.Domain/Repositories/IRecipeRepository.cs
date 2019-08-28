using System.Collections.Generic;
using Recipes.Domain.Models;
using System.Threading.Tasks;

namespace Recipes.Domain.Repositories
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Category>> ListCategoriesAsync();
        Task<Recipe> GetRecipeAsync(int recipeId);
    }
}
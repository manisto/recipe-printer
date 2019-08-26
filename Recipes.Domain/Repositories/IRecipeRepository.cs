using Recipes.Domain.Models;
using System.Threading.Tasks;

namespace Recipes.Domain.Repositories
{
    public interface IRecipeRepository
    {
        Task<Recipe> GetRecipeAsync(int recipeId);
    }
}
using System.Threading.Tasks;
using Recipes.Application.Dtos;

namespace Recipes.Application.Queries
{
    public interface IRecipeQueries
    {
        Task<RecipeDto> GetRecipeAsync(int recipeId);
    }
}
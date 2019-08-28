using System.Collections.Generic;
using System.Threading.Tasks;
using Recipes.Application.Dtos;

namespace Recipes.Application.Queries
{
    public interface IRecipeQueries
    {
        Task<IEnumerable<CategoryDto>> ListCategoriesAsync();
        Task<RecipeDto> GetRecipeAsync(int recipeId);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Recipes.Application.Dtos;

namespace Recipes.Application.Queries
{
    public interface IRecipeQueries
    {
        Task<IEnumerable<CategoryDto>> ListCategoriesAsync();
        Task<IEnumerable<RecipeDto>> ListRecipesAsync();
        Task<CategoryDto> GetCategoryAsync(int categoryId);
        Task<RecipeDto> GetRecipeAsync(int recipeId);
    }
}
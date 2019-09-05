using Recipes.Application.Dtos;
using Recipes.Domain.Models;

namespace Recipes.Application.Mappers
{
    public interface IRecipeMapper
    {
        CategoryDto MapCategory(Category category);
        RecipeDto MapRecipe(Recipe recipe);

        RecipeListDto MapRecipeForList(Recipe recipe);
    }
}
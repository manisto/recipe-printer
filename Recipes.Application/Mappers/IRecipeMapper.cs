using Recipes.Application.Dtos;
using Recipes.Domain.Models;

namespace Recipes.Application.Mappers
{
    public interface IRecipeMapper
    {
        RecipeDto MapRecipe(Recipe recipe);
    }
}
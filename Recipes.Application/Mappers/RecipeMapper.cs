using Recipes.Application.Dtos;
using Recipes.Domain.Models;

namespace Recipes.Application.Mappers
{
    public class RecipeMapper : IRecipeMapper
    {
        public RecipeDto MapRecipe(Recipe recipe)
        {
            return new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
            };
        }
    }
}
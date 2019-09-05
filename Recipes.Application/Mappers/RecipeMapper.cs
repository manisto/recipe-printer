using Recipes.Application.Dtos;
using Recipes.Domain.Models;

namespace Recipes.Application.Mappers
{
    public class RecipeMapper : IRecipeMapper
    {
        public CategoryDto MapCategory(Category category)
        {
            if (category == null)
            {
                return null;
            }

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
            };
        }
        
        public RecipeDto MapRecipe(Recipe recipe)
        {
            if (recipe == null)
            {
                return null;
            }
            
            return new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Ingredients = recipe.Ingredients,
                Preparation = recipe.Preparation,
            };
        }
    }
}
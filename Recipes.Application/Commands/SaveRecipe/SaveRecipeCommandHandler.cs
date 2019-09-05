using Recipes.Domain.Repositories;
using Recipes.Domain.Models;
using System.Threading.Tasks;

namespace Recipes.Application.Commands.SaveRecipe
{
    public class SaveRecipeCommandHandler : ISaveRecipeCommandHandler
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly ICategoryRepository _categoryRepository;

        public SaveRecipeCommandHandler
        (
            IRecipeRepository recipeRepository,
            ICategoryRepository categoryRepository
        )
        {
            this._recipeRepository = recipeRepository;
            this._categoryRepository = categoryRepository;
        }

        public async Task HandleAsync(SaveRecipeCommand command)
        {
            Recipe recipe = await _recipeRepository.GetRecipeAsync(command.Id);

            if (recipe == null)
            {
                recipe = new Recipe();
                _recipeRepository.AddRecipe(recipe);
            }

            recipe.Name = command.Name;
            recipe.Ingredients = command.Ingredients;
            recipe.Preparation = command.Preparation;

            recipe.RecipeCategories.Clear();

            foreach (int categoryId in command.Categories)
            {
                Category category = await _categoryRepository.GetCategoryAsync(categoryId);
                recipe.RecipeCategories.Add(new RecipeCategory(recipe, category));
            }

            await _recipeRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}
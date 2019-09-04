using System.Threading.Tasks;
using Recipes.Application.Dtos;
using Recipes.Application.Commands;
using Recipes.Domain.Models;
using Recipes.Domain.Repositories;

namespace Recipes.Application.Commands
{
    public class SaveCategoryCommandHandler : ISaveCategoryCommandHandler
    {
        private readonly IRecipeRepository _recipeRepository;

        public SaveCategoryCommandHandler
        (
            IRecipeRepository recipeRepository
        )
        {
            this._recipeRepository = recipeRepository;
        }

        public async Task HandleAsync(SaveCategoryCommand command)
        {
            Category category = await _recipeRepository.GetCategoryAsync(command.Id);

            if (category == null) {
                category = new Category(command.Name);
                _recipeRepository.AddCategory(category);
            }

            category.Name = command.Name;
            await _recipeRepository.SaveChangesAsync();
        }
    }
}
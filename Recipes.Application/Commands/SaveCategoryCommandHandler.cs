using System.Threading.Tasks;
using Recipes.Application.Dtos;
using Recipes.Application.Commands;
using Recipes.Domain.Models;
using Recipes.Domain.Repositories;

namespace Recipes.Application.Commands
{
    public class SaveCategoryCommandHandler : ISaveCategoryCommandHandler
    {
        private readonly ICategoryRepository _categoryRepository;

        public SaveCategoryCommandHandler
        (
            ICategoryRepository categoryRepository
        )
        {
            this._categoryRepository = categoryRepository;
        }

        public async Task HandleAsync(SaveCategoryCommand command)
        {
            Category category = await _categoryRepository.GetCategoryAsync(command.Id);

            if (category == null) {
                category = new Category(command.Name);
                _categoryRepository.AddCategory(category);
            }

            category.Name = command.Name;
            await _categoryRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}
using System.Threading.Tasks;
using Recipes.Application.Dtos;
using Recipes.Application.Commands;

namespace Recipes.Application.Commands
{
    public interface ISaveCategoryCommandHandler
    {
        Task HandleAsync(SaveCategoryCommand command);
    }
}
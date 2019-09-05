using System.Threading.Tasks;

namespace Recipes.Application.Commands
{
    public interface ISaveCategoryCommandHandler
    {
        Task HandleAsync(SaveCategoryCommand command);
    }
}
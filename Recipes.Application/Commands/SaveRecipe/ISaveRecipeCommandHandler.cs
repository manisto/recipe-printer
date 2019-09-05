using System.Threading.Tasks;

namespace Recipes.Application.Commands.SaveRecipe
{
    public interface ISaveRecipeCommandHandler
    {
        Task HandleAsync(SaveRecipeCommand command);
    }
}
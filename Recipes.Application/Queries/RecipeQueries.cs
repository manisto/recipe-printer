using System.Threading.Tasks;
using Recipes.Application.Dtos;
using Recipes.Application.Mappers;
using Recipes.Domain.Models;
using Recipes.Domain.Repositories;

namespace Recipes.Application.Queries
{
    public class RecipeQueries : IRecipeQueries
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeMapper _recipeMapper;

        public RecipeQueries
        (
            IRecipeRepository recipeRepository,
            IRecipeMapper recipeMapper
        )
        {
            _recipeRepository = recipeRepository;
            _recipeMapper = recipeMapper;
        }

        public async Task<RecipeDto> GetRecipeAsync(int recipeId)
        {
            Recipe recipe = await _recipeRepository.GetRecipeAsync(recipeId);
            RecipeDto recipeDto = _recipeMapper.MapRecipe(recipe);
            return recipeDto;
        }
    }
}
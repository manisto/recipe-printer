using System.Collections.Generic;
using System.Threading.Tasks;
using Recipes.Application.Dtos;
using Recipes.Application.Mappers;
using Recipes.Domain.Models;
using Recipes.Domain.Repositories;
using System.Linq;

namespace Recipes.Application.Queries
{
    public class RecipeQueries : IRecipeQueries
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeMapper _recipeMapper;

        public RecipeQueries
        (
            ICategoryRepository categoryRepository,
            IRecipeRepository recipeRepository,
            IRecipeMapper recipeMapper
        )
        {
            _categoryRepository = categoryRepository;
            _recipeRepository = recipeRepository;
            _recipeMapper = recipeMapper;
        }

        public async Task<CategoryDto> GetCategoryAsync(int categoryId)
        {
            Category category = await _categoryRepository.GetCategoryAsync(categoryId);
            CategoryDto categoryDto = _recipeMapper.MapCategory(category);
            return categoryDto;
        }

        public async Task<IEnumerable<CategoryDto>> ListCategoriesAsync()
        {
            IEnumerable<Category> categories = await _categoryRepository.ListCategoriesAsync();
            IEnumerable<CategoryDto> CategoryDtos = categories.Select(category => _recipeMapper.MapCategory(category));
            return CategoryDtos;
        }

        public async Task<RecipeDto> GetRecipeAsync(int recipeId)
        {
            Recipe recipe = await _recipeRepository.GetRecipeAsync(recipeId);
            RecipeDto recipeDto = _recipeMapper.MapRecipe(recipe);
            return recipeDto;
        }

        public async Task<IEnumerable<RecipeDto>> ListRecipesAsync()
        {
            IEnumerable<Recipe> recipes = await _recipeRepository.ListRecipesAsync();
            IEnumerable<RecipeDto> recipeDtos = recipes.Select(recipe => _recipeMapper.MapRecipe(recipe));
            return recipeDtos;
        }
    }
}
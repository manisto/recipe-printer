using System.Collections.Generic;
using Recipes.Domain.Models;
using System.Threading.Tasks;

namespace Recipes.Domain.Repositories
{
    public interface IRecipeRepository
    {
        Task<Category> GetCategoryAsync(int categoryId);
        Task<IEnumerable<Category>> ListCategoriesAsync();

        void AddCategory(Category category);
        Task<Recipe> GetRecipeAsync(int recipeId);

        Task SaveChangesAsync();
    }
}
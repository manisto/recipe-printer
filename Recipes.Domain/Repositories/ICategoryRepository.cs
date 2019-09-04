using System.Threading.Tasks;
using System.Collections.Generic;
using Recipes.Domain.Models;

namespace Recipes.Domain.Repositories
{
    public interface ICategoryRepository : IRepository
    {
        Task<Category> GetCategoryAsync(int categoryId);
        Task<IEnumerable<Category>> ListCategoriesAsync();
        void AddCategory(Category category);
    }
}
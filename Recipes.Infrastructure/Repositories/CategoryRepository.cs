using Recipes.Domain.Repositories;
using System.Threading.Tasks;
using Recipes.Domain.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Recipes.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly RecipesDbContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public CategoryRepository
        (
            RecipesDbContext context
        )
        {
            this._context = context;
        }

        public async Task<Category> GetCategoryAsync(int categoryId)
        {
            return await _context.Categories.FindAsync(categoryId);
        }

        public async Task<IEnumerable<Category>> ListCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
        }
    }
}
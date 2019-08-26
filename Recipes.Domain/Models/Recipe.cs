using System.Collections.Generic;

namespace Recipes.Domain.Models
{
    public class Recipe
    {
        public int Id { get; }
        public string Name { get; }

        public ICollection<RecipeCategory> RecipeCategories { get; }
    }
}
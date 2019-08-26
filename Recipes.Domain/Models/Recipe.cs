using System.Collections.Generic;

namespace Recipes.Domain.Models
{
    public class Recipe
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public ICollection<RecipeCategory> RecipeCategories { get; private set; }
    }
}
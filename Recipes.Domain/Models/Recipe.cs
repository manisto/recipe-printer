using System.Collections.Generic;

namespace Recipes.Domain.Models
{
    public class Recipe
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Preparation { get; set; }
        public string Ingredients { get; set; }

        public ICollection<RecipeCategory> RecipeCategories { get; private set; }
    }
}
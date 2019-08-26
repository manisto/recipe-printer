namespace Recipes.Domain.Models
{
    public class RecipeCategory
    {
        public Recipe Recipe { get; }
        public Category Category { get; }

        #region EF Core
        
        private RecipeCategory() { }

        #endregion

        public RecipeCategory(Recipe recipe, Category category)
        {
            Recipe = recipe;
            Category = category;
        }
    }
}
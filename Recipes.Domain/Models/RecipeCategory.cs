namespace Recipes.Domain.Models
{
    public class RecipeCategory
    {
        public int Id { get; private set; }
        public Recipe Recipe { get; private set; }
        public Category Category { get; private set; }

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
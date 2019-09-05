using System.Collections.Generic;

namespace Recipes.Application.Commands.SaveRecipe
{
    public class SaveRecipeCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Preparation { get; set; }
        public IEnumerable<int> Categories { get; set; }
    }
}
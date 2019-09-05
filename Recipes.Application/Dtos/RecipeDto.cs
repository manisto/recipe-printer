using System.Collections.Generic;

namespace Recipes.Application.Dtos
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        public string Preparation { get; set; }
        public string Ingredients { get; set; }
    }
}
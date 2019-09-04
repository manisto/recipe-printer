namespace Recipes.Domain.Models
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; set; }

        #region EF Core
        
        private Category() { }

        #endregion

        public Category(string name)
        {
            Name = name;
        }
    }
}
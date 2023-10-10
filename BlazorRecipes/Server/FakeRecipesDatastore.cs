using BlazorRecipes.Shared;
using BlazorRecipes.Shared.Recipes;

namespace BlazorRecipes.Server
{
    public class FakeRecipesDatastore
    {
        private readonly List<Recipe> _recipes;

        public FakeRecipesDatastore()
        {
            // Generate sample data
            var recipeFaker = new RecipeFaker();
            var recipes = recipeFaker.Generate(18);
            
            _recipes = recipes;
        }

        public IEnumerable<Recipe> GetFakeRecipes()
        {
            return _recipes;
        }
    }
}

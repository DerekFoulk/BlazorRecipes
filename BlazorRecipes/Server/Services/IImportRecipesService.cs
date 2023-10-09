using BlazorRecipes.Shared.Recipes;

namespace BlazorRecipes.Server.Services
{
    public interface IImportRecipesService
    {
        IEnumerable<Recipe> GetRecipesFromApi();
    }
}
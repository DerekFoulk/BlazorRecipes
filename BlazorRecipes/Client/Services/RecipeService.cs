using System.Net.Http.Json;
using BlazorRecipes.Shared.Recipes;

namespace BlazorRecipes.Client.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly HttpClient _httpClient;

        public RecipeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Recipe>?> GetAllRecipesAsync()
        {
            var recipes = await _httpClient.GetFromJsonAsync<Recipe[]>("Recipes");

            return recipes;
        }
    }
}

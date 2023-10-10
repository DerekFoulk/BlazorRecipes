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

        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            var recipes = await _httpClient.GetFromJsonAsync<Recipe[]>("Recipes") ?? Array.Empty<Recipe>();

            return recipes;
        }

        public async Task<Recipe?> GetRecipeById(int recipeId)
        {
            var recipe = await _httpClient.GetFromJsonAsync<Recipe>($"Recipes/{recipeId}");

            return recipe;
        }
    }
}

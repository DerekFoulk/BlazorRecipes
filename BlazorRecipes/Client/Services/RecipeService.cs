using System.Net.Http.Json;
using BlazorRecipes.Shared.Recipes;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace BlazorRecipes.Client.Services
{
    public class RecipeService
    {
        private readonly HttpClient _httpClient;

        public RecipeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Recipe>?> GetAllRecipes()
        {
            var recipes = await _httpClient.GetFromJsonAsync<Recipe[]>("Recipes");
            
            return recipes;
        }
    }
}

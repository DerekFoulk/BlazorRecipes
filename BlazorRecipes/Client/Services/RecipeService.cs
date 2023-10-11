using System.Net.Http.Json;
using System.Text.Json;
using BlazorRecipes.Shared.Recipes;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorRecipes.Client.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public RecipeService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            var httpClient = await GetCorrectHttpClientAsync();

            var recipes = await httpClient.GetFromJsonAsync<Recipe[]>("Recipe") ?? Array.Empty<Recipe>();

            return recipes;
        }

        private async Task<HttpClient> GetCorrectHttpClientAsync()
        {
            var httpClient = _httpClient;

            var authState = await _authenticationStateProvider
                .GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity is not null && user.Identity.IsAuthenticated)
            {
                // $"{user.Identity.Name} is authenticated.";
            }
            else
            {
                // "The user is NOT authenticated."
                httpClient = new HttpClient
                {
                    BaseAddress = _httpClient.BaseAddress
                };
            }

            return httpClient;
        }

        public async Task<Recipe?> GetRecipeById(int recipeId)
        {
            var httpClient = await GetCorrectHttpClientAsync();

            var recipe = await httpClient.GetFromJsonAsync<Recipe>($"Recipe/{recipeId}");

            return recipe;
        }

        public async Task<Recipe?> AddOrUpdateRecipeAsync(Recipe recipe)
        {
            var response = await _httpClient.PostAsJsonAsync("Recipes", recipe);
            var content = await response.Content.ReadAsStringAsync();
            var returnedRecipe = JsonSerializer.Deserialize<Recipe>(content);

            return returnedRecipe;
        }
    }
}

using BlazorRecipes.Server.Models;
using BlazorRecipes.Shared.Recipes;

namespace BlazorRecipes.Server.Services
{
    public class ImportRecipesService : IImportRecipesService
    {
        private readonly ILogger<ImportRecipesService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public ImportRecipesService(ILogger<ImportRecipesService> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public IEnumerable<Recipe> GetRecipesFromApi()
        {
            using var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", "");
            httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", "");

            var maxRecipes = 100;
            var recipes = new List<Recipe>();
            var maxPulls = maxRecipes / 10; // 10 results per page from external API
            var pulls = 0;
            var offset = 0;

            while ((recipes.Count < maxRecipes) && (pulls < maxPulls))
            {
                GetPageFromApi(httpClient);
            }

            return recipes;
        }

        private void GetPageFromApi(HttpClient httpClient)
        {
            var response = httpClient.GetFromJsonAsync<ImportedRecipe>("https://recipe-by-api-ninjas.p.rapidapi.com/v1/recipe");
        }
    }
}

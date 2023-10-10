using System.Text.Json;
using BlazorRecipes.Client.Services;
using BlazorRecipes.Shared;
using FluentAssertions;
using RichardSzalay.MockHttp;

namespace BlazorRecipes.Client.UnitTests.Services
{
    public class RecipeServiceTest
    {
        [Fact]
        public async Task GetAllRecipes_ReturnsExpectedRecipes()
        {
            // Arrange
            var recipeFaker = new RecipeFaker();
            var expectedRecipes = recipeFaker.Generate(2);
            var expectedRecipesJson = JsonSerializer.Serialize(expectedRecipes);

            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("/Recipes")
                .Respond("application/json", expectedRecipesJson);
            var httpClient = new HttpClient(mockHttp)
            {
                BaseAddress = new Uri("https://localhost:7266/")
            };

            var recipeService = new RecipeService(httpClient);

            // Act
            var recipes = await recipeService.GetAllRecipesAsync();

            // Assert
            recipes.Should()
                .BeEquivalentTo(expectedRecipes);
        }

        [Fact]
        public async Task GetRecipeById_ReturnsExpectedRecipe()
        {
            // Arrange
            var recipeFaker = new RecipeFaker();
            var expectedRecipe = recipeFaker.Generate();
            var expectedRecipeJson = JsonSerializer.Serialize(expectedRecipe);

            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When($"/Recipes/{expectedRecipe.Id}")
                .Respond("application/json", expectedRecipeJson);
            var httpClient = new HttpClient(mockHttp)
            {
                BaseAddress = new Uri("https://localhost:7266/")
            };

            var recipeService = new RecipeService(httpClient);

            // Act
            var recipe = await recipeService.GetRecipeById(expectedRecipe.Id);

            // Assert
            recipe.Should()
                .BeEquivalentTo(expectedRecipe);
        }
    }
}

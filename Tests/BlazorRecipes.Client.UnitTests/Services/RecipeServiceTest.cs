using System.Text.Json;
using BlazorRecipes.Client.Services;
using BlazorRecipes.Shared.Recipes;
using Bogus;
using FluentAssertions;
using RichardSzalay.MockHttp;

namespace BlazorRecipes.Client.UnitTests.Services
{
    public class RecipeServiceTest
    {
        [Fact]
        public async Task GetAllRecipes_ReturnsArrayOfRecipes()
        {
            // Arrange
            var recipeFaker = new Faker<Recipe>();
            var expectedRecipes = recipeFaker.Generate(2);
            var expectedRecipesJson = JsonSerializer.Serialize(expectedRecipes);

            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("http://localhost/*")
                .Respond("application/json", expectedRecipesJson);
            var httpClient = new HttpClient(mockHttp);

            var recipeService = new RecipeService(httpClient);

            // Act
            var recipes = await recipeService.GetAllRecipesAsync();

            // Assert
            recipes.Should()
                .BeEquivalentTo(expectedRecipes);
        }
    }
}

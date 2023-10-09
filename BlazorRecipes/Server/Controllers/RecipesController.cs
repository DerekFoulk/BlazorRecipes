using BlazorRecipes.Shared.Recipes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace BlazorRecipes.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class RecipesController
    {
        private readonly ILogger<RecipesController> _logger;

        public RecipesController(ILogger<RecipesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Recipe> Get()
        {
            var recipes = new List<Recipe>
            {
                // Grilled Cheese Sandwich
                new()
                {
                    Id = 0,
                    Title = "Grilled Cheese Sandwich",
                    Description = "Learn how to make a grilled cheese sandwich in a nonstick pan with buttered bread and American Cheddar for a classic hot sandwich.",
                    Image = "https://placehold.co/600x400?text=Grilled+Cheese+Sandwich",
                    Ingredients = new List<Ingredient>
                    {
                        new()
                        {
                            Text = "4 slices white bread"
                        },
                        new()
                        {
                            Text = "3 tablespoons butter, divided"
                        },
                        new()
                        {
                            Text = "2 slices Cheddar cheese"
                        }
                    },
                    Instructions = new List<Instruction>
                    {
                        new()
                        {
                            Text = "Preheat a nonstick skillet over medium heat. Generously butter one side of a slice of bread. Place bread butter-side down in the hot skillet; add 1 slice of cheese. Butter a second slice of bread on one side and place butter-side up on top of cheese."
                        },
                        new()
                        {
                            Text = "Cook until lightly browned on one side; flip over and continue cooking until cheese is melted. Repeat with remaining 2 slices of bread, butter, and slice of cheese."
                        }
                    },
                    Details = new Details
                    {
                        PrepTime = new TimeSpan(0, 5, 0),
                        CookTime = new TimeSpan(0, 10, 0),
                        Servings = 2
                    }
                },
                
                // To Die For Fettuccine Alfredo
                new()
                {
                    Id = 1,
                    Title = "To Die For Fettuccine Alfredo",
                    Description = "I created this fettuccine Alfredo by modifying my mother's recipe. I get nothing but rave reviews when I make this dish. My boyfriend is a fettuccine Alfredo connoisseur, and he scrapes the pan every time. I must warn you, this recipe is not for the health-conscious!",
                    Image = "https://placehold.co/600x400?text=To+Die+For+Fettuccine+Alfredo",
                    Ingredients = new List<Ingredient>
                    {
                        new()
                        {
                            Text = "24 ounces dry fettuccine pasta"
                        },
                        new()
                        {
                            Text = "1 cup butter"
                        },
                        new()
                        {
                            Text = "\u00be pint heavy cream"
                        },
                        new()
                        {
                            Text = "salt and pepper to taste"
                        },
                        new()
                        {
                            Text = "1 dash garlic salt"
                        },
                        new()
                        {
                            Text = "\u00be cup grated Romano cheese"
                        },
                        new()
                        {
                            Text = "\u00bd cup grated Parmesan cheese"
                        }
                    },
                    Instructions = new List<Instruction>
                    {
                        new()
                        {
                            Text = "Bring a large pot of lightly salted water to a boil. Add fettuccine and cook for 8 to 10 minutes or until al dente; drain."
                        },
                        new()
                        {
                            Text = "Melt butter into cream in a large saucepan over low heat; add salt, pepper, and garlic salt. Increase the heat to medium; stir in grated Romano and Parmesan cheese until melted and sauce has thickened."
                        },
                        new()
                        {
                            Text = "Add cooked pasta to sauce and toss until thoroughly coated; serve immediately."
                        }
                    },
                    Details = new Details
                    {
                        PrepTime = new TimeSpan(0, 15, 0),
                        CookTime = new TimeSpan(0, 15, 0),
                        Servings = 6
                    }
                }
            };

            return recipes;
        }
    }
}

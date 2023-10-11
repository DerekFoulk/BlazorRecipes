using BlazorRecipes.Server.Models;
using BlazorRecipes.Shared.Recipes;

namespace BlazorRecipes.Server
{
    public static class RecipesDbInitializer
    {
        public static void Initialize(RecipesContext context)
        {
            context.Database.EnsureCreated();
            
            if (context.Recipes.Any())
                return;

            var recipes = new Recipe[]
            {
                new()
                {
                    Title = "Grilled Cheese",
                    Description = "A classic, made with local ingredients.",
                    Image = "grilled-cheese.jpg",
                    Ingredients = new Ingredient[]
                    {
                        new()
                        {
                            Text = "2 slices of Franz White Bread"
                        },
                        new()
                        {
                            Text = "1 slice of Tillamook Medium Cheddar Cheese"
                        },
                        new()
                        {
                            Text = "1 Tbsp. of Salted butter"
                        }
                    },
                    Instructions = new Instruction[]
                    {
                        new()
                        {
                            Text = "Butter bread on both sides"
                        },
                        new()
                        {
                            Text = "Put a skillet on a stove-top burner at medium heat"
                        },
                        new()
                        {
                            Text = "Place both slices of bread on the skillet"
                        },
                        new()
                        {
                            Text = "Heat bread for 30-45 seconds"
                        },
                        new()
                        {
                            Text = "Flip bread and put the slice of Tillamook Cheddar on one of your slices"
                        },
                        new()
                        {
                            Text = "Let bread brown for 30-45 seconds)"
                        },
                        new()
                        {
                            Text = "Flip sandwich over and heat for 30-45 seconds"
                        },
                        new()
                        {
                            Text = "Remove from skillet"
                        },
                        new()
                        {
                            Text = "Plate and serve warm"
                        }
                    },
                    Details = new Details
                    {
                        PrepTime = new TimeSpan(0, 0, 30),
                        CookTime = new TimeSpan(0, 1, 30),
                        Servings = 1
                    }
                }
            };

            foreach (var recipe in recipes)
                context.Recipes.Add(recipe);

            context.SaveChanges();
        }
    }
}

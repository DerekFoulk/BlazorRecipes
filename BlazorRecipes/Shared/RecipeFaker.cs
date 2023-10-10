using BlazorRecipes.Shared.Recipes;
using Bogus;

namespace BlazorRecipes.Shared
{
    public sealed class RecipeFaker : Faker<Recipe>
    {
        public RecipeFaker()
        {
            var detailsFaker = new Faker<Details>()
                .Rules((f, d) =>
                {
                    d.PrepTime = f.Date.Timespan(TimeSpan.FromHours(3));
                    d.CookTime = f.Date.Timespan(TimeSpan.FromHours(6));
                    d.Servings = f.Random.Int(1, 8);
                });
            var ingredientsFaker = new Faker<Ingredient>()
                .Rules((f, i) =>
                {
                    i.Text = f.Random.Words(3);
                });
            var instructionsFaker = new Faker<Instruction>()
                .Rules((f, i) =>
                {
                    i.Text = f.Lorem.Text();
                });

            Rules((f, r) =>
            {
                var title = f.Random.Words(f.Random.Int(1, 3));

                r.Id = f.IndexFaker;
                r.Title = title;
                r.Description = f.Random.Words(f.Random.Int(5, 15));
                r.Image = f.Image.PlaceholderUrl(600, 400, title);
                r.Ingredients = ingredientsFaker.Generate(f.Random.Int(3, 10));
                r.Instructions = instructionsFaker.Generate(f.Random.Int(3, 10));
                r.Details = detailsFaker.Generate();
            });
        }
    }
}

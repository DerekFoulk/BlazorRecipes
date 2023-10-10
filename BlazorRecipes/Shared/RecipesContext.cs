using BlazorRecipes.Shared.Recipes;
using Microsoft.EntityFrameworkCore;

namespace BlazorRecipes.Shared
{
    public class RecipesContext : DbContext
    {
        public RecipesContext(DbContextOptions<RecipesContext> options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
    }
}

using BlazorRecipes.Shared.Recipes;
using Microsoft.EntityFrameworkCore;

namespace BlazorRecipes.Server.Models
{
    public class RecipesContext : DbContext
    {
        public RecipesContext(DbContextOptions<RecipesContext> options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
    }
}

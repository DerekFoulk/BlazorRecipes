using BlazorRecipes.Server.Models;
using BlazorRecipes.Shared.Recipes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web.Resource;

namespace BlazorRecipes.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class RecipeController : ControllerBase
    {
        private readonly ILogger<RecipeController> _logger;
        private readonly RecipesContext _recipesContext;

        public RecipeController(ILogger<RecipeController> logger, RecipesContext recipesContext)
        {
            _logger = logger;
            _recipesContext = recipesContext;
        }

        [HttpGet]
        public IEnumerable<Recipe> GetAll()
        {
            var recipes = _recipesContext.Recipes
                .Include(recipe => recipe.Ingredients)
                .Include(recipe => recipe.Instructions)
                .Include(recipe => recipe.Details)
                .ToList();

            return recipes;
        }

        [HttpGet("{id:int}")]
        public ActionResult<Recipe> Get(int id)
        {
            var recipe = _recipesContext.Recipes.Find(id);

            if (recipe == null)
                return NotFound();

            return Ok(recipe);
        }

        [Authorize]
        [HttpPost]
        public ActionResult<Recipe> Post(Recipe recipe)
        {
            _recipesContext.Recipes.Add(recipe);

            _recipesContext.SaveChanges();

            return Ok(recipe);
        }

        [Authorize]
        [HttpPut]
        public ActionResult<Recipe> Put(Recipe recipe)
        {
            var existingRecipe = _recipesContext.Recipes.Find(recipe.Id);

            if (existingRecipe == null)
                return BadRequest();

            _recipesContext.Entry(existingRecipe).CurrentValues.SetValues(recipe);

            _recipesContext.SaveChanges();

            return Ok(recipe);
        }

        [Authorize]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var existingRecipe = _recipesContext.Recipes.Find(id);

            if (existingRecipe == null)
                return BadRequest();

            _recipesContext.Recipes.Remove(existingRecipe);

            _recipesContext.SaveChanges();

            return Ok();
        }
    }
}

using BlazorRecipes.Shared.Recipes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace BlazorRecipes.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class RecipesController : ControllerBase
    {
        private readonly ILogger<RecipesController> _logger;

        private readonly List<Recipe> _recipes;

        public RecipesController(ILogger<RecipesController> logger, FakeRecipesDatastore fakeRecipesDatastore)
        {
            _logger = logger;
            
            _recipes = fakeRecipesDatastore.GetFakeRecipes().ToList();
        }

        [HttpGet]
        public IEnumerable<Recipe> GetAll()
        {
            return _recipes;
        }

        [HttpGet("{id:int}")]
        public ActionResult<Recipe> Get(int id)
        {
            var recipe = _recipes.SingleOrDefault(x => x.Id == id);

            if (recipe == null)
                return NotFound();

            return Ok(recipe);
        }

        [Authorize]
        [HttpPost]
        public ActionResult<Recipe> Post(Recipe recipe)
        {
            if (recipe.Id == default)
                recipe.Id = GetNextId();

            _recipes.Add(recipe);
            
            return Ok(recipe);
        }

        [Authorize]
        [HttpPut]
        public ActionResult<Recipe> Put(Recipe recipe)
        {
            var index = _recipes.IndexOf(recipe);

            if (index == -1)
                return BadRequest();

            _recipes[index] = recipe;

            return Ok(recipe);
        }

        [Authorize]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var existingRecipe = _recipes.SingleOrDefault(x => x.Id == id);

            if (existingRecipe == null)
                return BadRequest();

            _recipes.Remove(existingRecipe);

            return Ok();
        }

        private int GetNextId()
        {
            var maxId = _recipes.Max(x => x.Id);

            var id = maxId + 1;

            return id;
        }
    }
}

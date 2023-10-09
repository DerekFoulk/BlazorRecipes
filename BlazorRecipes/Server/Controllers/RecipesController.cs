using BlazorRecipes.Shared;
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
    public class RecipesController : ControllerBase
    {
        private readonly ILogger<RecipesController> _logger;

        private readonly IEnumerable<Recipe> _recipes;

        public RecipesController(ILogger<RecipesController> logger, FakeRecipesDatastore fakeRecipesDatastore)
        {
            _logger = logger;
            
            _recipes = fakeRecipesDatastore.GetFakeRecipes();
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

            return recipe;
        }
    }
}

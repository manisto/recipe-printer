using Recipes.Application.Dtos;
using Recipes.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Recipes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeQueries _recipeQueries;

        public RecipesController
        (
            IRecipeQueries recipeQueries
        )
        {
            _recipeQueries = recipeQueries;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeDto>> Get(int id)
        {
            return await _recipeQueries.GetRecipeAsync(id);
        }
    }
}
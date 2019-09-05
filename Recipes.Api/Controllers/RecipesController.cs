using Recipes.Application.Dtos;
using Recipes.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Recipes.Application.Commands.SaveRecipe;
using System.Collections.Generic;

namespace Recipes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeQueries _recipeQueries;
        private readonly ISaveRecipeCommandHandler _saveRecipeCommandHandler;

        public RecipesController
        (
            IRecipeQueries recipeQueries,
            ISaveRecipeCommandHandler saveRecipeCommandHandler
        )
        {
            _recipeQueries = recipeQueries;
            _saveRecipeCommandHandler = saveRecipeCommandHandler;
        }

        [HttpGet]
        public async Task<IEnumerable<RecipeListDto>> List()
        {
            return await _recipeQueries.ListRecipesAsync();
        }

        [HttpGet("prototype")]
        public ActionResult<RecipeDto> Prototype()
        {
            return new RecipeDto();
        }

        [HttpGet("{recipeId}")]
        public async Task<ActionResult<RecipeDto>> Get(int recipeId)
        {
            return await _recipeQueries.GetRecipeAsync(recipeId);
        }

        [HttpPost()]
        public async Task<ActionResult> Save(SaveRecipeCommand command)
        {
            await _saveRecipeCommandHandler.HandleAsync(command);
            return Ok();
        }
    }
}
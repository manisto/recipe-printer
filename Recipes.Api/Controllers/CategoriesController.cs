using System.Collections.Generic;
using Recipes.Application.Dtos;
using Recipes.Application.Commands;
using Recipes.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Recipes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IRecipeQueries _recipeQueries;
        private readonly ISaveCategoryCommandHandler _saveCategoryCommandHandler;

        public CategoriesController
        (
            IRecipeQueries recipeQueries,
            ISaveCategoryCommandHandler saveCategoryCommandHandler
        )
        {
            _recipeQueries = recipeQueries;
            _saveCategoryCommandHandler = saveCategoryCommandHandler;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> List()
        {
            return await _recipeQueries.ListCategoriesAsync();
        }

        [HttpGet("prototype")]
        public ActionResult<CategoryDto> Prototype()
        {
            return new CategoryDto();
        }

        [HttpGet("{categoryId}")]
        public async Task<ActionResult<CategoryDto>> Get(int categoryId)
        {
            return await _recipeQueries.GetCategoryAsync(categoryId);
        }

        [HttpPost()]
        public async Task<ActionResult> Save(SaveCategoryCommand command)
        {
            await _saveCategoryCommandHandler.HandleAsync(command);
            return Ok();
        }
    }
}
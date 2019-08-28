using System.Collections.Generic;
using Recipes.Application.Dtos;
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

        public CategoriesController
        (
            IRecipeQueries recipeQueries
        )
        {
            _recipeQueries = recipeQueries;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> Get()
        {
            return await _recipeQueries.ListCategoriesAsync();
        }
    }
}
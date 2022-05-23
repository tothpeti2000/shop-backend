using Domain.Models;
using Domain.Models.CategoryDTOs;
using Domain.Repositories;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService categoryService;

        public CategoriesController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("top")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetTopCategories()
        {
            var topCategories = await categoryService.GetTopCategoriesAsync();

            return Ok(topCategories);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetCategoryNodes()
        {
            var categories = await categoryService.GetCategoryNodesAsync();

            return Ok(categories);
        }
    }
}

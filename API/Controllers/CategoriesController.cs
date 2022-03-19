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

        public ActionResult<List<CategoryNode>> GetCategoryNodes()
        {
            return categoryService.GetCategoryNodes();
        }
    }
}

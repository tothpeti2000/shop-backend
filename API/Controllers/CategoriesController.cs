using Domain.Models;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository repository;

        public CategoriesController(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult<List<Category>> GetAllCategories()
        {
            return repository.GetAllCategories();
        }

        [Route("hierarchy")]
        public ActionResult<Dictionary<Category, List<Category>>> GetHierarchy()
        {
            return repository.GetCategoryHierarchy();
        }
    }
}

using Domain.Models;
using Domain.Models.CategoryDTOs;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CategoryService: BaseService
    {
        private readonly ICategoryRepository repository;

        public CategoryService(ICategoryRepository repository): base()
        {
            this.repository = repository;
        }

        public List<CategoryNode> GetCategoryNodes()
        {
            var categories = repository.GetAllCategories();

            return mapper.Map<List<Category>, List<CategoryNode>>(categories);
        }
    }
}

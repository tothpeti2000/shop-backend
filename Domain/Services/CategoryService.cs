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
    public class CategoryService
    {
        private readonly ICategoryRepository repository;

        public CategoryService(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public List<CategoryNode> GetCategoryNodes()
        {
            var categories = repository.GetAllCategories();

            //return mapper.Map<List<Category>, List<CategoryNode>>(categories);

            return null;
        }
    }
}

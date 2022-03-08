using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.MockRepositories
{
    public class MockCategoryRepository : ICategoryRepository
    {
        private List<Category> categories = new List<Category>()
        {
            new Category(1, "Construction toys", null),
            new Category(2, "LEGO", "Construction toys"),
            new Category(3, "F1 LEGO", "LEGO"),
            new Category(4, "Cars", null)
        };

        public List<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Dictionary<Category, List<Category>> GetCategoryHierarchy()
        {
            throw new NotImplementedException();
        }
    }
}

using Domain.Models;
using Domain.Models.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICategoryRepository
    {
        public Task<CategoryCover[]> GetTopCategoriesAsync();
        public Task<CategoryNode[]> GetCategoryNodesAsync();
    }
}

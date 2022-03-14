using DAL.DbObjects;
using Domain.Models.CategoryDTOs;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopContext db;

        public CategoryRepository(ShopContext db)
        {
            this.db = db;
        }

        public List<Category> GetAllCategories()
        {
            return db.Categories
                .Include(c => c.ParentCategory)
                .Select(ToModel)
                .ToList();
        }

        private Category ToModel(DbCategory dbCategory)
        {
            return new Category(dbCategory.ID, dbCategory.Name, dbCategory.ParentCategory?.Name ?? "");
        }
    }
}

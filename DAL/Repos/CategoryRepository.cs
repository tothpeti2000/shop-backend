using AutoMapper;
using DAL.DbObjects;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(ShopContext db): base(db) { }

        public override void AddProfiles(IMapperConfigurationExpression config)
        {
            throw new NotImplementedException();
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

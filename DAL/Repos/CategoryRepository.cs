using AutoMapper;
using DAL.DbObjects;
using DAL.Profiles;
using Domain.Models;
using Domain.Repositories;
using Domain.Services;
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
        private readonly Mapper<DbCategoryProfile> mapper;

        public CategoryRepository(ShopContext db)
        {
            this.db = db;
        }

        public List<Category> GetAllCategories()
        {
            var dbCategories = db.Categories
                .Include(c => c.ParentCategory)
                .ToList();

            //return mapper.Map<List<DbCategory>, List<Category>>(dbCategories);

            return null;
        }
    }
}

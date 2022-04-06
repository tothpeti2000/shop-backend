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

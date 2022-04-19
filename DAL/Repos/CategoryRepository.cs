using AutoMapper;
using DAL.DbObjects;
using DAL.Profiles;
using Domain.Models;
using Domain.Models.CategoryDTOs;
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
        private readonly Mapper<DbCategoryProfile> mapper = new();

        public CategoryRepository(ShopContext db)
        {
            this.db = db;
        }

        public async Task<CategoryNode[]> GetCategoryNodesAsync()
        {
            var dbCategories = await db.Categories
                .ToArrayAsync();

            return mapper.Map<DbCategory[], CategoryNode[]>(dbCategories);
        }
    }
}

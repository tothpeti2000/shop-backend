using AutoMapper.QueryableExtensions;
using DAL.DbObjects;
using DAL.Profiles;
using Domain.Mapping.Profiles;
using Domain.Models;
using Domain.Models.Paging;
using Domain.Models.ProductDTOs;
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
    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext db;
        private readonly Mapper<DbProductProfile> mapper;

        public ProductRepository(ShopContext db) 
        {
            this.db = db;
            mapper = new Mapper<DbProductProfile>();
        }

        public async Task<PagedResponse<ProductListItem>> GetProductsPaged(int page, int limit, string? name)
        {
            var dbProducts = db.Products
                .OrderBy(p => p.ID)
                .Where(p => name == null ? true : p.Name.ToUpper().Contains(name.ToUpper()));

            var totalProducts = dbProducts.Count();

            var pagedDbProducts = await dbProducts
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToArrayAsync();

            var pagedProducts = mapper.Map<DbProduct[], ProductListItem[]>(pagedDbProducts);

            return new PagedResponse<ProductListItem>
            {
                Items = pagedProducts,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)totalProducts / limit),
                TotalItems = totalProducts
            };
        }

        public async Task<ProductDetails?> GetDetailsByID(int ID)
        {
            var dbProduct = await db.Products
                .FirstOrDefaultAsync(p => p.ID == ID);

            return mapper.Map<DbProduct, ProductDetails>(dbProduct);
        }

        public double GetMaxPrice()
        {
            return db.Products
                .Max(p => p.Price);
        }
    }
}

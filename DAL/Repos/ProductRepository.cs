using AutoMapper.QueryableExtensions;
using DAL.DbObjects;
using DAL.Profiles;
using Domain.Mapping.Profiles;
using Domain.Models;
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

        // TODO: Paging
        public async Task<PagedResponse<ProductListItem>> GetAllProducts(int page = 1, int count = 10)
        {
            var dbProducts = await db.Products
                .OrderBy(p => p.ID)
                .ToListAsync();

            var products = mapper.Map<List<DbProduct>, List<ProductListItem>>(dbProducts);

            //return Paginator<ProductListItem>.Paginate(products, page, count);
            return null;
        }

        public async Task<ProductDetails?> GetDetailsByID(int ID)
        {
            var dbProduct = await db.Products
                .FirstOrDefaultAsync(p => p.ID == ID);

            return mapper.Map<DbProduct, ProductDetails>(dbProduct);
        }

        // TODO: Paging
        public List<Product> GetProductsByName(string name)
        {
            var matchingDbProducts = db.Products
                .Include(p => p.Category)
                .Where(p => p.Name.ToLower().Contains(name.ToLower()))
                .ToList();

            return mapper.Map<List<DbProduct>, List<Product>>(matchingDbProducts);
        }

        public double GetMaxPrice()
        {
            return db.Products
                .Max(p => p.Price);
        }
    }
}

using AutoMapper;
using AutoMapper.QueryableExtensions;
using DAL.DbObjects;
using Domain.Models;
using Domain.Models.ProductDTOs;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(ShopContext db): base(db){ }

        public async Task<PagedResponse<ProductListItem>> GetAllProducts(int page = 1, int count = 10)
        {
            var dbProducts = await db.Products
                .OrderBy(p => p.ID)
                .ToListAsync();

            var products = mapper.Map<List<DbProduct>, List<ProductListItem>>(dbProducts);

            return Paginator<ProductListItem>.Paginate(products, page, count);
        }

        public Product? GetByID(int ID)
        {
            var dbProduct = db.Products
                .Include(p => p.Category)
                .FirstOrDefault(p => p.ID == ID);

            return mapper.Map<DbProduct, Product>(dbProduct);
        }

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

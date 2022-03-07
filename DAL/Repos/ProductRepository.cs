using DAL.DbObjects;
using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ProductRepository : IProductRepository
    {
        private readonly ProductContext db;

        public ProductRepository(ProductContext db)
        {
            this.db = db;
        }

        public List<Product> GetAllProducts()
        {
            return db.Products
                .Select(ToModel)
                .ToList();
        }

        private Product ToModel(DbProduct dbProduct)
        {
            return new Product(dbProduct.ID, dbProduct.Name, dbProduct.Price, dbProduct.Stock, dbProduct.Category.Name);
        }
    }
}

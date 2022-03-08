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
        private readonly ShopContext db;

        public ProductRepository(ShopContext db)
        {
            this.db = db;
        }

        public List<Product> GetAllProducts()
        {
            return db.Products
                .Select(ToModel)
                .ToList();
        }

        public Product GetByID(int ID)
        {
            var dbProduct = db.Products
                .FirstOrDefault(p => p.ID == ID);

            if (dbProduct == null)
            {
                return null;
            }

            return ToModel(dbProduct);
        }

        public bool AddToCart(int ID)
        {
            throw new NotImplementedException();
        }

        private Product ToModel(DbProduct dbProduct)
        {
            return new Product(dbProduct.ID, dbProduct.Name, dbProduct.Price, dbProduct.Stock, dbProduct.Category.Name);
        }
    }
}

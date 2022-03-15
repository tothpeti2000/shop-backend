using DAL.DbObjects;
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
    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext db;

        public ProductRepository(ShopContext db)
        {
            this.db = db;
        }

        public List<Product> GetAllProducts()
        {
            return db.Products
                .Include(p => p.Category)
                .Select(ToModel)
                .ToList();
        }

        public Product? GetByID(int ID)
        {
            var dbProduct = db.Products
                .Include(p => p.Category)
                .FirstOrDefault(p => p.ID == ID);

            return ToModel(dbProduct);
        }

        public ProductDetails GetProductDetails(int ID)
        {
            /*var dbProduct = db.Products
                .FirstOrDefault(p => p.ID == ID);

            if (dbProduct == null)
            {
                return null;
            }

            return ToProductDetails(dbProduct);*/

            return null;
        }

        public double GetMaxPrice()
        {
            return db.Products.Max(p => p.Price);
        }

        public bool AddToCart(int ID)
        {
            throw new NotImplementedException();
        }

        private Product? ToModel(DbProduct? dbProduct)
        {
            if (dbProduct == null)
            {
                return null;
            }

            return new Product(dbProduct.ID, dbProduct.Name, dbProduct.Price, dbProduct.Stock, dbProduct.Description, dbProduct.AverageRating, dbProduct.ImgURL);
        }

        /*private ProductDetails ToProductDetails(DbProduct dbProduct)
        {
            return new ProductDetails(dbProduct.ID, dbProduct.Name, dbProduct.Price, dbProduct.Stock, dbProduct.Description, dbProduct.AverageRating, dbProduct.ImgURL);
        }*/
    }
}
